﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BizProcess.Data.MySQL
{
    public class Organize : BizProcess.Data.Interface.IOrganize
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Organize()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">BizProcess.Data.Model.Organize实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(BizProcess.Data.Model.Organize model)
        {
            string sql = @"INSERT INTO Organize
				(ID,Name,Number,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note) 
				VALUES(@ID,@Name,@Number,@Type,@Status,@ParentID,@Sort,@Depth,@ChildsLength,@ChargeLeader,@Leader,@Note)";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ID", MySqlDbType.VarChar, 36){ Value = model.ID },
				new MySqlParameter("@Name", MySqlDbType.VarChar, 2000){ Value = model.Name },
				new MySqlParameter("@Number", MySqlDbType.VarChar, 900){ Value = model.Number },
				new MySqlParameter("@Type", MySqlDbType.Int32, -1){ Value = model.Type },
				new MySqlParameter("@Status", MySqlDbType.Int32, -1){ Value = model.Status },
				new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36){ Value = model.ParentID },
				new MySqlParameter("@Sort", MySqlDbType.Int32, -1){ Value = model.Sort },
				new MySqlParameter("@Depth", MySqlDbType.Int32, -1){ Value = model.Depth },
				new MySqlParameter("@ChildsLength", MySqlDbType.Int32, -1){ Value = model.ChildsLength },
				model.ChargeLeader == null ? new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200) { Value = DBNull.Value } : new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200) { Value = model.ChargeLeader },
				model.Leader == null ? new MySqlParameter("@Leader", MySqlDbType.VarChar, 200) { Value = DBNull.Value } : new MySqlParameter("@Leader", MySqlDbType.VarChar, 200) { Value = model.Leader },
				model.Note == null ? new MySqlParameter("@Note", MySqlDbType.Text, -1) { Value = DBNull.Value } : new MySqlParameter("@Note", MySqlDbType.Text, -1) { Value = model.Note }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">BizProcess.Data.Model.Organize实体类</param>
        public int Update(BizProcess.Data.Model.Organize model)
        {
            string sql = @"UPDATE Organize SET 
				Name=@Name,Number=@Number,Type=@Type,Status=@Status,ParentID=@ParentID,Sort=@Sort,Depth=@Depth,ChildsLength=@ChildsLength,ChargeLeader=@ChargeLeader,Leader=@Leader,Note=@Note
				WHERE ID=@ID";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@Name", MySqlDbType.VarChar, 2000){ Value = model.Name },
				new MySqlParameter("@Number", MySqlDbType.VarChar, 900){ Value = model.Number },
				new MySqlParameter("@Type", MySqlDbType.Int32, -1){ Value = model.Type },
				new MySqlParameter("@Status", MySqlDbType.Int32, -1){ Value = model.Status },
				new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36){ Value = model.ParentID },
				new MySqlParameter("@Sort", MySqlDbType.Int32, -1){ Value = model.Sort },
				new MySqlParameter("@Depth", MySqlDbType.Int32, -1){ Value = model.Depth },
				new MySqlParameter("@ChildsLength", MySqlDbType.Int32, -1){ Value = model.ChildsLength },
				model.ChargeLeader == null ? new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200) { Value = DBNull.Value } : new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200) { Value = model.ChargeLeader },
				model.Leader == null ? new MySqlParameter("@Leader", MySqlDbType.VarChar, 200) { Value = DBNull.Value } : new MySqlParameter("@Leader", MySqlDbType.VarChar, 200) { Value = model.Leader },
				model.Note == null ? new MySqlParameter("@Note", MySqlDbType.Text, -1) { Value = DBNull.Value } : new MySqlParameter("@Note", MySqlDbType.Text, -1) { Value = model.Note },
				new MySqlParameter("@ID", MySqlDbType.VarChar, 36){ Value = model.ID }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM Organize WHERE ID=@ID";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ID", MySqlDbType.VarChar){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<BizProcess.Data.Model.Organize> DataReaderToList(MySqlDataReader dataReader)
        {
            List<BizProcess.Data.Model.Organize> List = new List<BizProcess.Data.Model.Organize>();
            BizProcess.Data.Model.Organize model = null;
            while (dataReader.Read())
            {
                model = new BizProcess.Data.Model.Organize();
                model.ID = dataReader.GetGuid(0);
                model.Name = dataReader.GetString(1);
                model.Number = dataReader.GetString(2);
                model.Type = dataReader.GetInt32(3);
                model.Status = dataReader.GetInt32(4);
                model.ParentID = dataReader.GetGuid(5);
                model.Sort = dataReader.GetInt32(6);
                model.Depth = dataReader.GetInt32(7);
                model.ChildsLength = dataReader.GetInt32(8);
                if (!dataReader.IsDBNull(9))
                    model.ChargeLeader = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    model.Leader = dataReader.GetString(10);
                if (!dataReader.IsDBNull(11))
                    model.Note = dataReader.GetString(11);
                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<BizProcess.Data.Model.Organize> GetAll()
        {
            string sql = "SELECT * FROM Organize";
            MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<BizProcess.Data.Model.Organize> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Organize";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public BizProcess.Data.Model.Organize Get(Guid id)
        {
            string sql = "SELECT * FROM Organize WHERE ID=@ID";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ID", MySqlDbType.VarChar){ Value = id }
			};
            MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<BizProcess.Data.Model.Organize> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }


        /// <summary>
        /// 查询根记录
        /// </summary>
        public BizProcess.Data.Model.Organize GetRoot()
        {
            string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ParentID", MySqlDbType.VarChar){ Value = Guid.Empty }
			};
            MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<BizProcess.Data.Model.Organize> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

        /// <summary>
        /// 查询下级记录
        /// </summary>
        public List<BizProcess.Data.Model.Organize> GetChilds(Guid ID)
        {
            string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID ORDER BY Sort";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ParentID", MySqlDbType.VarChar){ Value = ID }
			};
            MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<BizProcess.Data.Model.Organize> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

        /// <summary>
        /// 得到最大排序值
        /// </summary>
        /// <returns></returns>
        public int GetMaxSort(Guid id)
        {
            string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM Organize WHERE ParentID=@ParentID";
            MySqlParameter[] parameters = new MySqlParameter[]{
				new MySqlParameter("@ParentID", MySqlDbType.VarChar){ Value = id }
			};
            string sort = dbHelper.GetFieldValue(sql, parameters);
            return sort.ToInt();
        }

        /// <summary>
        /// 更新下级数
        /// </summary>
        /// <returns></returns>
        public int UpdateChildsLength(Guid id, int length)
        {
            string sql = "UPDATE Organize SET ChildsLength=@ChildsLength WHERE ID=@ID";
            MySqlParameter[] parameters = new MySqlParameter[]{
                new MySqlParameter("@ChildsLength", MySqlDbType.Int32){ Value = length },
				new MySqlParameter("@ID", MySqlDbType.VarChar){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <returns></returns>
        public int UpdateSort(Guid id, int sort)
        {
            string sql = "UPDATE Organize SET Sort=@Sort WHERE ID=@ID";
            MySqlParameter[] parameters = new MySqlParameter[]{
                new MySqlParameter("@Sort", MySqlDbType.Int32){ Value = sort },
				new MySqlParameter("@ID", MySqlDbType.VarChar){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }

        /// <summary>
        /// 查询一个组织的所有上级
        /// </summary>
        public List<BizProcess.Data.Model.Organize> GetAllParent(string number)
        {
            string sql = "SELECT * FROM Organize WHERE ID IN(" + BizProcess.Utility.Tools.GetSqlInString(number) + ") ORDER BY Depth";
            MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<BizProcess.Data.Model.Organize> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

        /// <summary>
        /// 查询一个组织的所有下级
        /// </summary>
        /// <param name="number">编号</param>
        /// <returns></returns>
        public List<BizProcess.Data.Model.Organize> GetAllChild(string number)
        {
            string sql = "SELECT * FROM Organize WHERE Number LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort";
            MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<BizProcess.Data.Model.Organize> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }

    }
}