using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using IWshRuntimeLibrary;
//using System.Cos;
//using System.Linq;llections.Generic;
//using System.Diagnostic;
//using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Text;
using System.Management;
using System.Collections;
using System.Drawing;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Windows;
using Microsoft.Win32;
using System.Net;
using System.Data.SqlClient;

namespace ERP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
            
        }
    }
    public static class Globals
    {
        public static int ScreenWith=Screen.PrimaryScreen.WorkingArea.Width;
        public static int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;
        public static string dpath = "";
        public static DataGridView MinFormLocation = new DataGridView();
        public static string vtype = "";
        public static string sqlQuery = "";
        public static string iniConnectionString = "";
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter adapter;
        public static SqlDataReader reader;
        public static string SoftName;
        public static string Softexe;
        public static int MsgResult;
        public static bool SearchEnterKey=false;
        public static string SoftPath = "";
        public static string ServerName = "";
        public static string DatabaseName = "";
        public static DateTime ServerDateTime = new DateTime();
        public static Dictionary<string, string> setting = new Dictionary<string, string>();
        public static int msgbox(Form frm,string msg="", string criteria= "Ok,Center")
        {                 
            frmMessage frm1 = new frmMessage();
            frm1.Message(msg , criteria);
            frm1.ShowDialog(frm);
            return MsgResult;
        }
        public static void ClearAllFields(Form frm)
        {
            foreach (Control ctl in frm.Controls)
            {
                if (ctl.HasChildren && ctl is Panel)
                {
                    foreach (Control ctl1 in ctl.Controls)
                    {
                        if (ctl1 is uctxt)
                        {
                            ((uctxt)ctl1).txt.Text = "";
                        }
                        //else if (ctl1 is ucSearchList)
                        //{
                        //    ((ucSearchList)ctl1).txt.Text = "";
                        //}
                    }
                }
                else
                {
                    if (ctl is uctxt)
                    {
                        ((uctxt)ctl).txt.Text = "";
                    }
                    //else if (ctl is ucSearchList)
                    //{
                    //    ((ucSearchList)ctl).txt.Text = "";
                    //}
                }
            }
        }
        public static void START()
        {
            bool temp = false;
            try
            {
                //vtype = "REST";  //RESTAURANT
                //SoftName = "RESTAURANT v1.0.0";
                //Softexe = "RESTAURANT";

                vtype = "EASY";  //ACCOUNTING
                SoftName = "INVENTORY SOFTWARE WITH GST v1.0.0";
                Softexe = "INVENTORY SOFTWARE";

                Connect(); //- Database Connection----
               // temp = IsPirated();
                //if (temp == true || temp == false)
                //{ frmAlert f = new frmAlert(); f.Show(); }

            }
            catch (Exception ex)
            { //msgbox(ex.Message);Application.Exit(); 
            }
        }

        public static void Connect()
        {
            string ConnectionString = "";
            try
            {
                if (DatabaseName.Trim().Length>0)
                {
                    iniConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";User ID=sa;Password=vin0101";
                    ConnectionString = iniConnectionString;
                    con = new SqlConnection();
                    con.ConnectionString = ConnectionString;
                    con.Open();
                }
                else
                { MessageBox.Show("Something Missing...");Application.Exit(); }
            }
            catch (Exception ex)
            {
                     MessageBox.Show(ex.Message);
                    Application.Exit();
            }
        }
        public static int MaxCode(string tblName,string colName,string criteria="")
        {
            //MName = '" & cName.Tstr & "' and MType = '" & MType & "'"
            int max=0;
            sqlQuery = "Select Max(" + colName + ") from " + tblName + "";
            cmd = new SqlCommand(sqlQuery , con);
            reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                max =Convert.ToInt32(val(reader[0].ToString()))+ 1;
            }
            else
            {
                max = 1;
            }
            reader.Close();
            cmd.Dispose();
            return max;
        }
        public static bool chkRecord(string tblName , string criteria)
        {
            bool chk=false;
            sqlQuery = "Select * from " + tblName + " where " + criteria;
            cmd = new SqlCommand(sqlQuery , con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                chk = true;
            }
            else
            {
                chk = false;
            }
            reader.Close();
            cmd.Dispose();
            return chk;
        }
        public static bool chkRecord(string tblName , int value)
        {
            bool chk = false;
            sqlQuery = "Select * from " + tblName + " where SNo=" + value;
            cmd = new SqlCommand(sqlQuery , con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                chk = true;
            }
            else
            {
                chk = false;
            }
            return chk;
        }
        public static void DeleteRecord(string tblName , object value)
        {
            sqlQuery = "Delete from " + tblName + " where SNo=" + value;
            cmd = new SqlCommand(sqlQuery , con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();          
        }
        
        public static void DeleteRecord(string tblName , string criteria)
        {
            sqlQuery = "Delete from " + tblName + " where "+ criteria;
            cmd = new SqlCommand(sqlQuery , con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        //public static ListBox LoadList(Form frm,string vtype = "" , string criteria = "")
        //{
        //    ListBox temp = new ListBox();
        //    temp.Items.Clear();
        //    try
        //    {
        //        if (vtype == "m_master")
        //        {
        //            sqlQuery = "Select SNo,MName from m_master where MType='" + criteria + "' order by MName";
        //            cmd = new SqlCommand(sqlQuery , con);
        //            reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ucSearchList.MList lst = new ucSearchList.MList();
        //                lst.Code = int.Parse(reader["SNo"].ToString());
        //                lst.Name = reader["MName"].ToString();
        //                temp.Items.Add(lst);
        //            }
        //            temp.ClearSelected();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Globals.msgbox(frm , ex.Message);
        //    }
        //    cmd.Dispose();
        //    reader.Close();
        //    return temp;
        //}
        public static void LoadList(Form frm , ListBox temp , string vtype = "" , string criteria = "")
        {
            temp.Items.Clear();
            try
            {
                if (vtype == "m_master")
                {
                    sqlQuery = "Select SNo,MName from m_master where MType='" + criteria + "' order by MName";
                    cmd = new SqlCommand(sqlQuery , con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ucSearchList.MList lst = new ucSearchList.MList();
                        lst.Code = int.Parse(reader["SNo"].ToString());
                        lst.Name = reader["MName"].ToString();
                        temp.Items.Add(lst);
                    }
                    temp.ClearSelected();
                }
                else
                    {
                    sqlQuery = vtype;
                    cmd = new SqlCommand(sqlQuery, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ucSearchList.MList lst = new ucSearchList.MList();
                        lst.Code = int.Parse(reader[0].ToString());
                        lst.Name = reader[1].ToString();
                        temp.Items.Add(lst);
                    }
                    if (temp.Items.Count > 0) temp.SelectedIndex = 0;
                    
                }
            }
            catch (Exception ex)
            {
                Globals.msgbox(frm , ex.Message);
            }
            cmd.Dispose();
            reader.Close();
        }

        public static void LoadList2(Form frm,ListBox temp,string[] data)
        {
            int i = 0;
            temp.Items.Clear();
            for( i = 0 ; i <data.Length; i++)
            {
                ucSearchList.MList st = new ucSearchList.MList();
                st.Name = data[i];
                st.Code = i;
                temp.Items.Add(st);
            }
            if(temp.Items.Count>0)
            {
                temp.SelectedIndex = 0;
            }            
        }


        public static void SetObjectResponsive()
        {
            return;
        }
        public static double val()
        {
            return 0;
        }
        private static double val(object value)
        {
            double Num = 0;
            if (Double.TryParse(value.ToString() , out Num))
            {
                return Num;
            }
            else
            {
                return 0;
            }
        }
        public static void SetColor()
        {
            return ;
        }
        public static void SetPosition()
        {
            return;
        }

        internal static int msgbox(string v)
        {
            throw new NotImplementedException();
        }
    }

    }
