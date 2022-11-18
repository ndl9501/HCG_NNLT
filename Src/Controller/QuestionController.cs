﻿using HCG_NNLT.Src.DbConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace WindowsFormsApp1.Controller
{
    public class QuestionController
    {
        dbConnect conn = new dbConnect();
        public QuestionController()
        {

        }
        public DataSet getAll(string table_name)
        {
            try
            {
                DataSet rs = new DataSet();
                string sql = "select * from tbl_Questions";
                rs = conn.getData(sql, table_name, null);
                return rs;
            }
            catch (Exception err)
            {
                throw;
            }
        }

        public DataSet getById(string table_name, List<SqlParameter> data)
        {
            try
            {
                DataSet rs = new DataSet();
                string sql = "select top 1 from tbl_Questions where QuestionId = @QuestionId";
                rs = conn.getData(sql, table_name, data);
                return rs;
            }
            catch (Exception err)
            {
                throw;
            }
        }

        public int insertData(List<SqlParameter> data)
        {
            try
            {
                string sql = "insert into tbl_Questions(QuestionID, Name) values (@QuestionID, @Name)";
                int rs = (int)conn.UpdateData(sql, data);
                return rs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int updateData(List<SqlParameter> data)
        {
            try
            {
                string sql = "update tbl_Questions set Name = @Name where QuestionID = @QuestionID";
                int rs = (int)conn.UpdateData(sql, data);
                return rs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int deleteData(List<SqlParameter> data)
        {
            try
            {
                string sql = "delete tbl_Questions where QuestionID = @QuestionID";
                int rs = (int)conn.UpdateData(sql, data);
                return rs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataSet search(string table_name, List<SqlParameter> data)
        {
            try
            {
                DataSet rs = new DataSet();
                string sql = "select * from tbl_Questions where Name like '%' + @Name + '%'";
                rs = conn.getData(sql, table_name, data);
                return rs;
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}