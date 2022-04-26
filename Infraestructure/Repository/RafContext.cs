using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace WeatherConcurrencyApp.Infrastructure.OpenWeatherClient
{
    public class RAFContext
    {
        private string fileName;
        private int size;
        private string temporal = "temporal";
        public RAFContext(string fileName, int size)
        {
            this.fileName = fileName;
            this.size = size;
        }

        public Stream HeaderStream
        {
            get => File.Open($"{fileName}.hd", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public Stream DataStream
        {
            get => File.Open($"{fileName}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public Stream TemporalHeader
        {
            get => File.Open($"{temporal}.tp", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Create<T>(T t)
        {
            try
            {
                using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream),
                                 bwData = new BinaryWriter(DataStream))
                {
                    int n = 0, k = 0;
                    using (BinaryReader brHeader = new BinaryReader(bwHeader.BaseStream))
                    {
                        if (brHeader.BaseStream.Length > 0)
                        {
                            brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                            n = brHeader.ReadInt32();
                            k = brHeader.ReadInt32();
                        }

                        //calculamos la posicion en Data
                        long pos = k * size;
                        bwData.BaseStream.Seek(pos, SeekOrigin.Begin);

                        PropertyInfo[] info = t.GetType().GetProperties();
                        foreach (PropertyInfo pinfo in info)
                        {
                            Type type = pinfo.PropertyType;
                            object obj = pinfo.GetValue(t, null);

                            if (type.IsGenericType)
                            {
                                continue;
                            }

                            if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                            {
                                bwData.Write(++k);
                                continue;
                            }

                            if (type == typeof(int))
                            {
                                bwData.Write((int)obj);
                            }
                            else if (type == typeof(long))
                            {
                                bwData.Write((long)obj);
                            }
                            else if (type == typeof(float))
                            {
                                bwData.Write((float)obj);
                            }
                            else if (type == typeof(double))
                            {
                                bwData.Write((double)obj);
                            }
                            else if (type == typeof(decimal))
                            {
                                bwData.Write((decimal)obj);
                            }
                            else if (type == typeof(char))
                            {
                                bwData.Write((char)obj);
                            }
                            else if (type == typeof(bool))
                            {
                                bwData.Write((bool)obj);
                            }
                            else if (type == typeof(string))
                            {
                                bwData.Write((string)obj);
                            }
                        }

                        long posh = 8 + n * 4;
                        bwHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                        bwHeader.Write(k);

                        bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        bwHeader.Write(++n);
                        bwHeader.Write(k);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update<T>(T t, int id)
        {
            try
            {
                using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream),
                                 bwData = new BinaryWriter(DataStream))
                {
                    //calculamos la posicion en Data
                    long pos = (id - 1) * size;
                    bwData.BaseStream.Seek(pos, SeekOrigin.Begin);

                    PropertyInfo[] info = t.GetType().GetProperties();
                    foreach (PropertyInfo pinfo in info)
                    {
                        Type type = pinfo.PropertyType;
                        object obj = pinfo.GetValue(t, null);

                        if (type.IsGenericType)
                        {
                            continue;
                        }

                        //if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                        //{
                        //    bwData.Write(++k);
                        //    continue;
                        //}

                        if (type == typeof(int))
                        {
                            bwData.Write((int)obj);
                        }
                        else if (type == typeof(long))
                        {
                            bwData.Write((long)obj);
                        }
                        else if (type == typeof(float))
                        {
                            bwData.Write((float)obj);
                        }
                        else if (type == typeof(double))
                        {
                            bwData.Write((double)obj);
                        }
                        else if (type == typeof(decimal))
                        {
                            bwData.Write((decimal)obj);
                        }
                        else if (type == typeof(char))
                        {
                            bwData.Write((char)obj);
                        }
                        else if (type == typeof(bool))
                        {
                            bwData.Write((bool)obj);
                        }
                        else if (type == typeof(string))
                        {
                            bwData.Write((string)obj);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete<T>(int id, List<int> listaIds)
        {
            try
            {
                int n = 0, k = 0;
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    n = brHeader.ReadInt32();
                    k = brHeader.ReadInt32();

                    int index = listaIds.BinarySearch(id);

                    using (BinaryWriter bwTemporal = new BinaryWriter(TemporalHeader))
                    {
                        bwTemporal.BaseStream.Seek(0, SeekOrigin.Begin);
                        bwTemporal.Write(--n);
                        bwTemporal.Write(k);

                        for (int i = 0; i < listaIds.Count; i++)
                        {
                            if (listaIds[i] != id)
                            {
                                bwTemporal.Write(listaIds[i]);
                            }
                        }

                    }
                }
                File.Delete($"{fileName}.hd");
                File.Copy($"{temporal}.tp", $"{fileName}.hd");
            }
            catch (Exception)
            {
                throw;
            }


        }

        public T Get<T>(int id)
        {
            try
            {
                T newValue = (T)Activator.CreateInstance(typeof(T));
                int n = 0, k = 0;
                using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                    brData = new BinaryReader(DataStream))
                {
                    if (brHeader.BaseStream.Length > 0)
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }

                    List<int> listaIds = new List<int>();
                    brHeader.BaseStream.Seek(8, SeekOrigin.Begin);

                    while (brHeader.BaseStream.Position < brHeader.BaseStream.Length)
                    {
                        listaIds.Add(brHeader.ReadInt32());
                    }

                    int indexId = listaIds.BinarySearch(id);

                    if (id <= 0 || id > k)
                    {
                        return default(T);
                    }

                    PropertyInfo[] properties = newValue.GetType().GetProperties();
                    long posh = 8 + indexId * 4;

                    //TODO Add Binary search to find the id
                    if (listaIds.BinarySearch(id) < 0)
                    {
                        return default(T);
                    }

                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    int index = brHeader.ReadInt32();
                    //TODO VALIDATE INDEX
                    long posd = (index - 1) * size;
                    brData.BaseStream.Seek(posd, SeekOrigin.Begin);
                    foreach (PropertyInfo pinfo in properties)
                    {
                        Type type = pinfo.PropertyType;

                        if (type.IsGenericType)
                        {
                            continue;
                        }

                        if (type == typeof(int))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<int>(TypeCode.Int32));
                        }
                        else if (type == typeof(long))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<long>(TypeCode.Int64));
                        }
                        else if (type == typeof(float))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<float>(TypeCode.Single));
                        }
                        else if (type == typeof(double))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<double>(TypeCode.Double));
                        }
                        else if (type == typeof(decimal))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<decimal>(TypeCode.Decimal));
                        }
                        else if (type == typeof(char))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<char>(TypeCode.Char));
                        }
                        else if (type == typeof(bool))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<bool>(TypeCode.Boolean));
                        }
                        else if (type == typeof(string))
                        {
                            pinfo.SetValue(newValue, brData.GetValue<string>(TypeCode.String));
                        }
                    }
                }
                return newValue;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetAll<T>()
        {
            List<T> listT = new List<T>();
            int n = 0, k = 0;

            try
            {
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    if (brHeader.BaseStream.Length > 0)
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }
                }

                if (n == 0)
                {
                    return listT;
                }


                for (int i = 0; i < n; i++)
                {
                    int index;

                    using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                    {
                        long posh = 8 + i * 4;
                        brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                        index = brHeader.ReadInt32();
                    }

                    T t = Get<T>(index);
                    listT.Add(t);
                }

                return listT;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProperty<T>(T t, int id)
        {
            try
            {
                using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream),
                                 bwData = new BinaryWriter(DataStream))
                {
                    //calculamos la posicion en Data
                    long pos = (id - 1) * size;
                    bwData.BaseStream.Seek(pos, SeekOrigin.Begin);

                    PropertyInfo[] info = t.GetType().GetProperties();
                    foreach (PropertyInfo pinfo in info)
                    {
                        Type type = pinfo.PropertyType;
                        object obj = pinfo.GetValue(t, null);

                        if (type.IsGenericType)
                        {
                            continue;
                        }

                        //if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                        //{
                        //    bwData.Write(++k);
                        //    continue;
                        //}

                        if (type == typeof(int))
                        {
                            bwData.Write((int)obj);
                        }
                        else if (type == typeof(long))
                        {
                            bwData.Write((long)obj);
                        }
                        else if (type == typeof(float))
                        {
                            bwData.Write((float)obj);
                        }
                        else if (type == typeof(double))
                        {
                            bwData.Write((double)obj);
                        }
                        else if (type == typeof(decimal))
                        {
                            bwData.Write((decimal)obj);
                        }
                        else if (type == typeof(char))
                        {
                            bwData.Write((char)obj);
                        }
                        else if (type == typeof(bool))
                        {
                            bwData.Write((bool)obj);
                        }
                        else if (type == typeof(string))
                        {
                            bwData.Write((string)obj);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<T> Find<T>(Expression<Func<T, bool>> where)
        {
            List<T> listT = new List<T>();
            int n = 0, k = 0;
            Func<T, bool> comparator = where.Compile();
            try
            {
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    if (brHeader.BaseStream.Length > 0)
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }

                }

                if (n == 0)
                {
                    return listT;
                }

                for (int i = 0; i < n; i++)
                {
                    int index;
                    using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                    {
                        long posh = 8 + i * 4;
                        brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                        index = brHeader.ReadInt32();
                    }

                    T t = Get<T>(index);
                    if (comparator(t))
                    {
                        listT.Add(t);
                    }

                }
                return listT;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int GetLastId()
        {
            int k = 0;
            try
            {

                using (BinaryReader br = new BinaryReader(HeaderStream))
                {
                    if (br.BaseStream.Length == 0)
                    {
                        return k;
                    }
                    long posh = 4;
                    br.BaseStream.Seek(posh, SeekOrigin.Begin);
                    k = br.ReadInt32();
                }

            }
            catch (IOException)
            {
                throw;
            }
            return k;
        }
    }
}

