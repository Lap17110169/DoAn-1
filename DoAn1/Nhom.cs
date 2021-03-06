﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace DoAn1
{
    class Nhom
    {
        public bool insertNhom(string manhom, string tennhom, string tenphongban)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("INSERT INTO Nhom (MaNhom, TenNhom, TenPhongBan) " +
                "VALUES (@ma, @tenn, @tenpb)", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = manhom;
            command.Parameters.Add("@tenn", SqlDbType.NVarChar).Value = tennhom;
            command.Parameters.Add("@tenpb", SqlDbType.NVarChar).Value = tenphongban;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool deleteNhom(string ma)
        {
            MyDB mydb = new MyDB();
            SqlCommand cmd = new SqlCommand("DELETE FROM Nhom WHERE MaNhom = @ma ", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = ma;
            mydb.openConnection();
            if ((cmd.ExecuteNonQuery() == 1))
            {
                cmd.Dispose();
                mydb.closeConnection();
                return true;
            }
            else
            {
                cmd.Dispose();
                mydb.closeConnection();
                return false;
            }
        }
        public bool UpdateNhom(string manhom, string tennhom, string tenphongban)
        {
            MyDB mydb = new MyDB();
            SqlCommand command = new SqlCommand("UPDATE Nhom SET MaNhom=@ma,TenNhom=@tenn,TenPhongBan=@tenpb WHERE MaNhom=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.NVarChar).Value = manhom;
            command.Parameters.Add("@tenn", SqlDbType.NVarChar).Value = tennhom;
            command.Parameters.Add("@tenpb", SqlDbType.NVarChar).Value = tenphongban;

            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                command.Dispose();
                mydb.closeConnection();
                return true;
            }
            else
            {
                command.Dispose();
                mydb.closeConnection();
                return false;
            }
        }
    }
}
