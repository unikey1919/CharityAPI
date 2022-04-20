using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CharityAPI.Helper
{
    public static class ObjectExtension
    {

        public static T ToObject<T>(this DataRow row) where T : new()
        {
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            T result = new T();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in row.Table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            var item = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);

            return item;
        }
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            if (table == null)
                return null;
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            List<T> result = new List<T>();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);
                result.Add(item);
            }

            return result;
        }

        public static T ToObject<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<PropertyInfo> lstPropertiesAdd = new List<PropertyInfo>();
            T result = new T();

            #region Lấy các thuộc tính có trong Object và trong table
            List<string> lstColumnName = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                lstColumnName.Add(col.ColumnName.ToUpper());
            }

            foreach (PropertyInfo objPI in properties)
            {
                if (lstColumnName.Contains(objPI.Name.ToUpper()))
                    lstPropertiesAdd.Add(objPI);
            }
            #endregion

            foreach (var row in table.Rows)
            {
                result = CreateItemFromRow<T>((DataRow)row, lstPropertiesAdd);
                break;
            }

            return result;
        }

        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            try
            {
                foreach (var property in properties)
                {
                    if (row[property.Name] != System.DBNull.Value)
                    {
                        try
                        {
                            property.SetValue(item, System.Convert.ChangeType(row[property.Name], property.PropertyType), null);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Thieu field trong view
            }
            return item;
        }
        #region
        /// <summary>
        /// Khởi tạo danh sách cho một kiểu dữ liệu elementType.
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public static IList CreateList(this Type elementType)
        {
            Type listGenericType = typeof(List<>).MakeGenericType(elementType);
            return (IList)Activator.CreateInstance(listGenericType);
        }
        /// <summary>
        /// Tạo mới đối tượng có kiểu elementType.
        /// </summary>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public static object CreateInstance(this Type elementType)
        {
            return Activator.CreateInstance(elementType);
        }

        /// <summary>
        /// Gán giá trị cho thuộc tính propertyName.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object entity, string propertyName, object value)
        {
            SetPropertyValue(entity, propertyName, value, BindingFlags.Default);
        }
        public static void SetPropertyValue(this object entity, string propertyName, object value, BindingFlags bindingAttr)
        {
            if (entity != null && !string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyInfo propertyInfo = null;

                if (bindingAttr == BindingFlags.Default)
                {
                    propertyInfo = entity.GetType().GetProperty(propertyName);
                }
                else
                {
                    propertyInfo = entity.GetType().GetProperty(propertyName, bindingAttr);
                }

                entity.SetPropertyValue(propertyInfo, value);
            }
        }
        public static void SetPropertyValue(this object entity, PropertyInfo propertyInfo, object value)
        {
            if (entity != null && propertyInfo != null && propertyInfo.CanWrite)
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString())
                    && propertyInfo.PropertyType == typeof(XElement))
                {
                    value = XElement.Parse(value.ToString());
                }

                if (propertyInfo.PropertyType.IsEnum)
                {
                    value = Enum.ToObject(propertyInfo.PropertyType, value);
                }

                value = value == DBNull.Value ? null : value;
                propertyInfo.SetValue(entity, value, null);
            }
        }
        public static IList Translate(this DataTable dataTable, Type objectType, params string[] excludedFields)
        {
            IList listEntity = objectType.CreateList();
            ParallelOptions options = new ParallelOptions();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //DataRow dataRow = dataTable.Rows[d];
                var entity = objectType.CreateInstance();

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    string propertyName = dataColumn.ColumnName;

                    if (excludedFields == null || !excludedFields.Contains(propertyName))
                    {

                        PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
                        //PropertyInfo propertyInfo = lstPropertyInfo.FirstOrDefault(x => x.Name.ToUpper().Equals(propertyName));


                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            try
                            {
                                entity.SetPropertyValue(propertyInfo, dataRow[dataColumn]);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message + " - " + dataColumn.ColumnName);
                            }
                        }
                    }
                }

                lock (listEntity)
                {
                    //Lock để khỏi xung đột
                    listEntity.Add(entity);
                }
            }

            return listEntity;
        }
        /// <summary>
        /// Convert data reader thành danh sách TEntity.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<TEntity> Translate<TEntity>(this DataTable dataTable, params string[] excludedFields)
        {
            IList listEntity = dataTable.Translate(typeof(TEntity), excludedFields);
            return listEntity.OfType<TEntity>().ToList();
        }
        #endregion
        #region DataTable
        public static DataTable ToUpperColumnName(this DataTable table)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                table.Columns[i].ColumnName = table.Columns[i].ColumnName.ToUpper();
            }
            return table;
        }
        #endregion
    }
}
