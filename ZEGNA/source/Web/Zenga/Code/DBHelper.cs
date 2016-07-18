
using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using System.Data.SqlClient;
using System.Collections;
using IBatisNet.Common;
using IBatisNet.Common.Pagination;
using System.Web;
using IBatisNet.DataMapper.Configuration;
using System.IO;
using IBatisNet.DataMapper.SessionStore;

namespace Zenga.Web.Code
{
    public class DBHelper : System.Web.UI.Page
    {
        public ISqlMapper mapper = null;

        //sqlmap.config 放在站点根目录下,即可直接instanc(),并且去掉构造方法
        //public ISqlMapper mapper =Mapper.Instance();

        public DBHelper()
        {
            string s = Server.MapPath(@"/config/SqlMap.config");
            Init(s);
        }


        public void Init(string configPath)
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            this.mapper = builder.Configure(configPath);

            //mapper.SessionStore = new HybridWebThreadSessionStore(mapper.Id);
        }

        public DataSet QueryForDataSet(string statementName, object paramObject)
        {
            DataSet ds = new DataSet();

            IMappedStatement statement = mapper.GetMappedStatement(statementName);
            if (!mapper.IsSessionStarted)
            {
                mapper.OpenConnection();
            }
            RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, mapper.LocalSession);
            statement.PreparedCommand.Create(scope, mapper.LocalSession, statement.Statement, paramObject);
            IDbCommand command = mapper.LocalSession.CreateCommand(CommandType.Text);
            command.CommandText = scope.IDbCommand.CommandText;

            foreach (IDataParameter pa in scope.IDbCommand.Parameters)
            {
                command.Parameters.Add(new SqlParameter(pa.ParameterName, pa.Value));
            }

            mapper.LocalSession.CreateDataAdapter(command).Fill(ds);
            return ds;
        }

        public string GetSql(string tag, object paramObject)
        {
            //ISqlMapper sqlMap = Mapper.Instance();


            //测试时使用，随时加载配置文件
            //IBatisNet.DataMapper.Configuration.DomSqlMapBuilder builder =
            //    new IBatisNet.DataMapper.Configuration.DomSqlMapBuilder();
            //ISqlMapper sqlMap = builder.Configure();

            IBatisNet.DataMapper.ISqlMapSession m_sqlSession;
            if (mapper.LocalSession != null)
            {
                m_sqlSession = mapper.LocalSession;
            }
            else
            {
                m_sqlSession = mapper.OpenConnection();
            }
            IMappedStatement statement = mapper.GetMappedStatement(tag);
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, paramObject, m_sqlSession);

            return request.PreparedStatement.PreparedSql;
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public IList QueryForList(string statementName, object parameterObject)
        {
            try
            {
                return mapper.QueryForList(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="skipResults"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        protected IList QueryForList(string statementName, object parameterObject, int skipResults, int maxResults)
        {
            try
            {
                return mapper.QueryForList(statementName, parameterObject, skipResults, maxResults);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + statementName + "' for list.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected IPaginatedList QueryForPaginatedList(string statementName, object parameterObject, int pageSize)
        {

            try
            {
                return mapper.QueryForPaginatedList(statementName, parameterObject, pageSize);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + statementName + "' for paginated list.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected object QueryForObject(string statementName, object parameterObject)
        {

            try
            {
                return mapper.QueryForObject(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + statementName + "' for object.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected int Update(string statementName, object parameterObject)
        {
            //ISqlMapper sqlMap =Mapper.Instance();

            try
            {
                return mapper.Update(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + statementName + "' for update.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StatementName"></param>
        /// <param name="ParameterObject"></param>
        /// <returns></returns>
        public int Delete(string StatementName, object ParameterObject)
        {
            //ISqlMapper sqlmap =Mapper.Instance();
            try
            {
                return mapper.Delete(StatementName, ParameterObject);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + StatementName + "' for REMOVE.  Cause: " + e.Message, e);
            }
        }

        /// <summary>
        /// Simple convenience method to wrap the SqlMap method of the same name.
        /// Wraps the exception with a IBatisNetException to isolate the SqlMap framework.
        /// </summary>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        protected object Insert(string statementName, object parameterObject)
        {
            //ISqlMapper sqlMap =Mapper.Instance();

            try
            {
                return mapper.Insert(statementName, parameterObject);
            }
            catch (Exception e)
            {
                throw new Exception("Error executing query '" + statementName + "' for insert.  Cause: " + e.Message, e);
            }
        }

        //返回IDbCommand的函数
        private IDbCommand GetDbCommand(string statementName, object parameterObject)
        {
            IDbCommand p_command;
            IBatisNet.DataMapper.ISqlMapSession m_sqlSession;

            //ISqlMapper sqlMap =Mapper.Instance();
            if (mapper.LocalSession != null)
            {
                m_sqlSession = mapper.LocalSession;
            }
            else
            {  
                m_sqlSession = mapper.OpenConnection();
            }
            //IMappedStatement mappedStatement = Mapper.Instance().GetMappedStatement(statementName);
            IMappedStatement mappedStatement = this.mapper.GetMappedStatement(statementName);
            RequestScope requestScope = mappedStatement.Statement.Sql.GetRequestScope(mappedStatement, parameterObject, m_sqlSession);
            // 通过这个方法生成一个DbCommand，并且给所有的SQL参数指定值。如果没有调用此方法，requestScope.IDbCommand属性为空  // 
            mappedStatement.PreparedCommand.Create(requestScope,
             m_sqlSession, mappedStatement.Statement, parameterObject);
            p_command = requestScope.IDbCommand;
            return p_command;
        }

        //实现返回DataSet的函数
        public void QueryXml(string statementName, object parameterObject, string xmlPath)
        {
            DataSet ds = QueryTable(statementName, parameterObject, string.Empty);
            System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(xmlPath, System.Text.Encoding.GetEncoding("gb2312"));
            xtw.WriteRaw("<?xml   version=\"1.0\"   encoding=\"gb2312\"?>");
            ds.WriteXml(xtw);
            xtw.Close();
        }

        //实现返回DataSet的函数
        public DataSet QueryTable(string statementName, object parameterObject, string sql)
        {
            DataSet ds = new DataSet();
            using (IDbCommand cmd = GetDbCommand(statementName, parameterObject))
            {
                if (string.IsNullOrEmpty(sql))
                {
                    //未指定SQL语句
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    ds.Tables.Add(dt);
                }
                else
                {
                    //指定了SQL语句，重新建立Command对象， 复制原Command对象的参数列表，
                    //ISqlMapper mapper =Mapper.Instance();
                    using (IDbCommand cmd2 = mapper.LocalSession.CreateCommand(CommandType.Text))
                    {
                        cmd2.CommandText = sql;
                        foreach (IDbDataParameter o in cmd.Parameters)
                        {
                            IDbDataParameter p = cmd2.CreateParameter();
                            p.DbType = o.DbType;
                            p.Direction = o.Direction;
                            p.ParameterName = o.ParameterName;
                            p.Precision = o.Precision;
                            p.Scale = o.Scale;
                            p.Size = o.Size;
                            p.SourceColumn = o.SourceColumn;
                            p.SourceVersion = o.SourceVersion;
                            p.Value = o.Value;
                            cmd2.Parameters.Add(p);
                        }
                        IDbDataAdapter adapter = mapper.LocalSession.CreateDataAdapter(cmd2);
                        adapter.Fill(ds);
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>DataSet</returns>
        public DataSet QueryTableBySql(string sql)
        {
            DataSet ds = new DataSet();
            //ISqlMapper sqlMap = Mapper.Instance();
            IDalSession session = new IBatisNet.DataMapper.SqlMapSession(mapper);
            session.OpenConnection();
            try
            {
                IDbCommand cmd = session.CreateCommand(CommandType.Text);
                cmd.CommandText = sql;
                IDbDataAdapter adapter = session.CreateDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }
            finally
            {
                session.CloseConnection();
            }
        }

        /// <summary>
        /// <![CDATA[执行查询SQL返回IList<Hashtable>]]>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns><![CDATA[IList<Hashtable>]]></returns>
        public IList<Hashtable> QueryHashtableListBySql(string sql)
        {
            try
            {
                DataSet ds = QueryTableBySql(sql);
                if (ds.Tables.Count > 0)
                {
                    return DataTableToHash(ds.Tables[0]);
                }

                return new List<Hashtable>();
            }
            finally
            {
                //session.CloseConnection();
            }
        }

        private static IList<Hashtable> DataTableToHash(DataTable table)
        {
            IList<Hashtable> dataList = new List<Hashtable>();
            foreach (DataRow row in table.Rows)
            {
                Hashtable ht = new Hashtable();
                foreach (DataColumn dc in table.Columns)
                {
                    ht[dc.ColumnName] = row[dc];
                }
                dataList.Add(ht);
            }
            return dataList;
        }

        public System.Data.DataSet QueryForPagedDataset(string sql,
            int pageSize, int pageIndex, string indexCol, string order, int total)
        {
            //翻页处理
            int recCount = pageSize;
            if (pageIndex * pageSize > total)
            {
                recCount += total - pageIndex * pageSize;
            }
            if (!string.IsNullOrEmpty(order))
            {
                indexCol = order + "," + indexCol;
            }
            string aorder = Antitone(indexCol);
            string sqlNo = string.Format("SELECT TOP {0} * FROM ({2}) LCQA ORDER BY {1}",
                pageIndex * pageSize, indexCol, sql);
            sql = string.Format("SELECT TOP {0} * FROM ({1}) LCQB ORDER BY {2}",
                recCount, sqlNo, aorder);
            if (!string.IsNullOrEmpty(order))
            {
                sql = string.Format("SELECT * FROM ({0}) LCQC ORDER BY {1}",
                    sql, order);
            }
            else
            {
                sql = string.Format("SELECT * FROM ({0}) LCQC ORDER BY {1}",
                    sql, indexCol);
            }
            if (!string.IsNullOrEmpty(sql))
            {
                return QueryTableBySql(sql);
            }
            else
            {
                return new DataSet();
            }
        }

        public int QueryForRecordCount(string sql)
        {
            //记录数
            sql = string.Format("SELECT COUNT(*) FROM ({0}) LCQZ", sql);

            DataSet ds = QueryTableBySql(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return (int)ds.Tables[0].Rows[0][0];
            }
            return 0;
        }

        /// <summary>
        /// 查询表分布数据，利用SQL2005的ROW_NUMBER函数
        /// </summary>
        /// <param name="statementName">SQL语句ID名称</param>
        /// <param name="parameterObject">参数对象</param>
        /// <param name="pageSize">每页行数</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="indexCol"></param>
        /// <param name="order">排序字段表达式，例如：order by Field1 desc</param>
        /// <param name="total">总行数，本方法不需要此参数</param>
        /// <returns></returns>
        public System.Data.DataSet QueryForPagedDataset(string statementName, object parameterObject,
            int pageSize, int pageIndex, string indexCol, string order, int total)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            //ISqlMapper sqlMap = Mapper.Instance();
            using (IDbCommand cmd = GetDbCommand(statementName, parameterObject))
            {
                int iRowBegin = pageIndex * pageSize + 1;
                int iRowEnd = (pageIndex + 1) * pageSize;
                //翻页处理
                cmd.CommandText = string.Format(
                    @"select * from (
                        select ROW_NUMBER() OVER ({1}) AS rown, GILDATA_ALIAS.* from 
                        ({0}) AS GILDATA_ALIAS 
                    ) AS GILDATA_ALIAS2
                    where GILDATA_ALIAS2.rown Between {2} and {3}",
                    cmd.CommandText,
                    order, iRowBegin, iRowEnd
                );
                dt.Load(cmd.ExecuteReader());
                dt.Columns.Remove("rown");
            }
            //.....
            return ds;
        }

        public IList<Hashtable> QueryForPagedList(string statementName, object parameterObject,
            int pageSize, int pageIndex, string indexCol, string order, int total)
        {
            //ISqlMapper sqlMap = Mapper.Instance();
            IDbCommand cmd = GetDbCommand(statementName, parameterObject);
            string sql = this.GetSql(statementName, parameterObject);
            //翻页处理
            int recCount = pageSize;
            if (pageIndex * pageSize > total)
            {
                recCount += total - pageIndex * pageSize;
            }
            if (!string.IsNullOrEmpty(order))
            {
                indexCol = order;
            }
            string aorder = Antitone(indexCol);
            string sqlNo = string.Format("SELECT TOP {0} * FROM ({2}) LCQA ORDER BY {1}",
                pageIndex * pageSize, indexCol, sql);
            sql = string.Format("SELECT TOP {0} * FROM ({1}) LCQB ORDER BY {2}",
                recCount, sqlNo, aorder);
            if (!string.IsNullOrEmpty(order))
            {
                sql = string.Format("SELECT * FROM ({0}) LCQC ORDER BY {1}",
                    sql, order);
            }
            else
            {
                sql = string.Format("SELECT * FROM ({0}) LCQC ORDER BY {1}",
                    sql, indexCol);
            }

            DataSet ds = QueryTable(statementName, parameterObject, sql);
            if (ds.Tables.Count > 0)
            {
                return DataTableToHash(ds.Tables[0]);
            }

            return new List<Hashtable>();
        }

        public int QueryForRecordCount(string statementName, object parameterObject)
        {
            DataSet ds = new DataSet();
            //ISqlMapper sqlMap = Mapper.Instance();
            IDbCommand cmd = GetDbCommand(statementName, parameterObject);
            string sql = this.GetSql(statementName, parameterObject);
            //记录数
            sql = string.Format("SELECT COUNT(*) FROM ({0}) LCQZ", sql);

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            int re = 0;
            try
            {
                re = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            return re;

        }

        //返回sql的函数 
        //返回对应的sql语句 
        public string GetSql(string tag, object paramObject, out IDbDataParameter[] idp)
        {
            //ISqlMapper sqlMap = Mapper.Instance();


            //测试时使用，随时加载配置文件
            //IBatisNet.DataMapper.Configuration.DomSqlMapBuilder builder =
            //    new IBatisNet.DataMapper.Configuration.DomSqlMapBuilder();
            //ISqlMapper sqlMap = builder.Configure();

            IBatisNet.DataMapper.ISqlMapSession m_sqlSession;
            if (mapper.LocalSession != null)
            {
                m_sqlSession = mapper.LocalSession;
            }
            else
            {
                m_sqlSession = mapper.OpenConnection();
            }
            IMappedStatement statement = mapper.GetMappedStatement(tag);
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, paramObject, m_sqlSession);
            IDbDataParameter[] ID = request.PreparedStatement.DbParameters;
            ID[0].Value = "2008-5-20";
            ID[1].Value = "2008-6-20";

            idp = ID;

            return request.PreparedStatement.PreparedSql;
        }

        /// <summary>
        /// 反转排序方式
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private string Antitone(string order)
        {
            string result = "";
            string[] ss = order.Trim().Split(',');
            foreach (string s in ss)
            {
                string[] sss = s.Trim().Split(' ');
                string v = GetValue(sss);

                if (result != "")
                {
                    result += ",";
                }
                result += v;
            }

            return result;
        }

        private string GetValue(string[] ss)
        {
            string result = "";
            bool isKey = false, isV = false;
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i].Trim() != "" && ss[i].Trim() != null)
                {
                    if (!isKey)
                    {
                        result = ss[i].Trim();
                        isKey = true;
                        continue;
                    }
                    if (!isV)
                    {
                        string s = ss[i].Trim().ToLower();
                        if (s != "desc" && s != "asc")
                        {
                            throw new Exception("索引属性格式不正确！");
                        }
                        result += " " + s;
                        isV = true;
                        break;
                    }
                }
            }
            if (isKey && !isV)
            {
                result += " " + "asc";
            }

            return result.Replace("desc", "ASC").Replace("asc", "DESC");
        }

        public IList<Hashtable> PagingDataIList(string field, string asc_desc, int pagesize, int start, string sqlText)
        {
            string sql = String.Format("WITH SecuMain_DataSet AS ( " +
                        " SELECT ROW_NUMBER() OVER " +
                        " (ORDER BY " + field + "   " + asc_desc + " ) AS Row," +
                        " *  FROM ( " + sqlText + " ) aa )" +
                        " SELECT * FROM SecuMain_DataSet " +
                        " WHERE Row between ({0}-1)* {1}+1  and {0}*{1}", start, pagesize);
            return QueryHashtableListBySql(sql);
        }
        public DataSet PagingDataDataSet(string field, string asc_desc, int pagesize, int start, string sqlText)
        {
            string sql = String.Format("WITH SecuMain_DataSet AS ( " +
                        " SELECT ROW_NUMBER() OVER " +
                        " (ORDER BY " + field + "   " + asc_desc + " ) AS Row," +
                        " *  FROM ( " + sqlText + " ) aa )" +
                        " SELECT * FROM SecuMain_DataSet " +
                        " WHERE Row between ({0}-1)* {1}+1  and {0}*{1}", start, pagesize);
            return QueryTableBySql(sql);
        }

        public object Find(string statementName, object keyValue)
        {
            object result = mapper.QueryForObject(statementName, keyValue);
            return result;
        }


    }
}