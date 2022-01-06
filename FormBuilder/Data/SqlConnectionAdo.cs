using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace FormBuilder.Data
{
    public class SqlConnectionAdo
    {
        private readonly IConfiguration configuration;
        public void Submit(string tblName, List<string> columnName)
        {
            string trim = Regex.Replace(tblName, @"\s", "");
            string tableName = trim;
            //List<string> columnList = columnName;
            List<string> columnList = new List<string>();
            foreach (var item in columnName)
            {
                string trimm = Regex.Replace(item, @"\s", "");
                columnList.Add(trimm);
            }
            string columnLists = String.Join(",", columnList);
            string createTableScript = string.Format("CREATE TABLE {0}([FormID] [int] IDENTITY(1,1) NOT NULL)", tableName);
            string addColumnScript = "ALTER TABLE {0} Add {1} [nvarchar](Max)";
            if (!CheckObjectExists(tableName, "CheckTableExists"))
            {
                /* If table object not exists then Create the Table*/
                ExecuteToSQL(createTableScript);
            }
            string alterColumnScript = string.Empty;

            /* By column list You Need to make Loop to check the column exists or not*/
            foreach (var columnname in columnList)
            {
                /* Check Column in Table */
                if (!CheckObjectExists(tableName, "CheckColumnExists", columnname))
                {
                    /* If column not exists then Add it to table*/
                    alterColumnScript = string.Format(addColumnScript, tableName, columnname);
                    ExecuteToSQL(alterColumnScript);
                }
            }

            /* Insert Script You Need to Maintain according to your Column with control value with proper order */
            string insertScript = string.Format(" INSERT INTO {0}({1}) ", tableName, columnLists);
            ExecuteToSQL(insertScript);
        }
        public void Insert(string tblName, List<string> columnName, string values)
        {
            string trim = Regex.Replace(tblName, @"\s", "");
            string tableName = trim;
            //List<string> columnList = columnName;
            List<string> columnList = new List<string>();
            foreach (var item in columnName)
            {
                string trimm = Regex.Replace(item, @"\s", "");
                columnList.Add(trimm);
            }
            string columnLists = String.Join(",", columnList);
            List<string> colLists = new List<string>();
            foreach (var item in values.Split(','))
            {
                string temp = "'" + item + "'";
                colLists.Add(temp);
            }
            string cols = String.Join(",", colLists);
            string insertScript = string.Format(" INSERT INTO {0}({1}) VALUES({2}) ", tableName, columnLists, cols);
            ExecuteToSQL(insertScript);
        }
        public void Delete(string tblName)
        {
            string trim = Regex.Replace(tblName, @"\s", "");
            string tableName = trim;
            if (CheckObjectExists(tableName, "CheckTableExists"))
            {
                /* If table object not exists then Create the Table*/
                string deleteScript = string.Format("DROP TABLE {0}", tblName);
                ExecuteToSQL(deleteScript);
            }

        }
        protected bool CheckObjectExists(string tableName, string spName, string columnname = "")
        {
            bool isObjectExist = false;
            string constr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-FormBuilder-B5DDBB83-DF30-4FA5-AB89-D08ED9B1540B;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (SqlConnection con = new(constr))
            {
                using (SqlCommand cmd = new(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        cmd.Parameters.AddWithValue("@ColumnName", columnname);
                    }
                    con.Open();
                    object IsExists = cmd.ExecuteScalar();
                    if (IsExists != null && IsExists != DBNull.Value)
                    {
                        isObjectExist = Convert.ToBoolean(IsExists);
                    }
                    con.Close();
                }
            }
            return isObjectExist;
        }
        protected void ExecuteToSQL(string sqlQuery)
        {
            string constr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-FormBuilder-B5DDBB83-DF30-4FA5-AB89-D08ED9B1540B;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new(constr))
            {
                using (SqlCommand cmd = new(sqlQuery, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }

        }
    }
}
