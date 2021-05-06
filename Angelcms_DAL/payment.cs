using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Angelcms_DBUtility;
using Angelcms_Common;
using Angelcms.Model;

namespace Angelcms.DAL
{
    /// <summary>
    /// ���ݷ�����:֧����ʽ
    /// </summary>
    public partial class payment
    {
        private string databaseprefix; //���ݿ����ǰ׺
        public payment(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region ��������
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "payment");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperMSSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ���ر�������
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "payment");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperMSSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "-";
            }
            return title;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Age_payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "payment(");
            strSql.Append("title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path)");
            strSql.Append(" values (");
            strSql.Append("@title,@img_url,@remark,@type,@poundage_type,@poundage_amount,@sort_id,@is_sys,@api_path)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_amount", SqlDbType.Decimal,5),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@api_path", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.img_url;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.type;
            parameters[4].Value = model.poundage_type;
            parameters[5].Value = model.poundage_amount;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.is_lock;
            parameters[8].Value = model.api_path;

            object obj = DbHelperMSSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "payment set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperMSSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Age_payment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "payment set ");
            strSql.Append("title=@title,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("remark=@remark,");
            strSql.Append("type=@type,");
            strSql.Append("poundage_type=@poundage_type,");
            strSql.Append("poundage_amount=@poundage_amount,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("api_path=@api_path");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@img_url", SqlDbType.NVarChar,255),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_type", SqlDbType.TinyInt,1),
					new SqlParameter("@poundage_amount", SqlDbType.Decimal,5),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@api_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.img_url;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.type;
            parameters[4].Value = model.poundage_type;
            parameters[5].Value = model.poundage_amount;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.is_lock;
            parameters[8].Value = model.api_path;
            parameters[9].Value = model.id;

            int rows = DbHelperMSSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "payment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperMSSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Age_payment GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path from " + databaseprefix + "payment ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Age_payment model = new Age_payment();
            DataSet ds = DbHelperMSSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["poundage_type"].ToString() != "")
                {
                    model.poundage_type = int.Parse(ds.Tables[0].Rows[0]["poundage_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["poundage_amount"].ToString() != "")
                {
                    model.poundage_amount = decimal.Parse(ds.Tables[0].Rows[0]["poundage_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                model.api_path = ds.Tables[0].Rows[0]["api_path"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path ");
            strSql.Append(" FROM " + databaseprefix + "payment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,id desc");
            return DbHelperMSSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,img_url,remark,type,poundage_type,poundage_amount,sort_id,is_lock,api_path ");
            strSql.Append(" FROM " + databaseprefix + "payment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperMSSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}