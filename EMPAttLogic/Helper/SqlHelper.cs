using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SqlHelper
/// </summary>
///
//chngesd
public class SqlHelper
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["CONSTR"].ToString());

    void ReConnection()
    {
        if (con.State != ConnectionState.Open)
        {
            con.Open();
        }
    }

    public SqlConnection GetConnection { get { return con; } }

    protected SqlCommand ExecuteProceduer(string ProceduerName, object[,] paramvalue, bool AddOutputparameter)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = ProceduerName;
        SqlConnection conn = new SqlConnection(con.ConnectionString);
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] param = new SqlParameter[paramvalue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + paramvalue[i, 0].ToString(), paramvalue[i, 1].ToString());
        }
        cmd.Parameters.AddRange(param);
        if (AddOutputparameter)
        {
            cmd.Parameters.Add("OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("OUTMSG", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
        }

        if (conn.State != ConnectionState.Open) { conn.Open(); }
        cmd.ExecuteNonQuery();
        conn.Close();
        return cmd;
    }

    protected MEMBERS.SQLReturnMessageNValue ExecuteProceduerWithMessage(string ProceduerName, object[,] paramvalue)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = ProceduerName;
        SqlConnection conn = new SqlConnection(con.ConnectionString);
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] param = new SqlParameter[paramvalue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + paramvalue[i, 0].ToString(), paramvalue[i, 1].ToString());
        }
        cmd.Parameters.AddRange(param);

        cmd.Parameters.Add("OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("OUTMSG", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;

        if (conn.State != ConnectionState.Open) { conn.Open(); }
        cmd.ExecuteNonQuery();
        conn.Close();
        MEMBERS.SQLReturnMessageNValue m = new MEMBERS.SQLReturnMessageNValue();
        m.Outmsg = cmd.Parameters["OUTMSG"].Value.ToString();
        m.Outval = int.Parse(cmd.Parameters["OUTVAL"].Value.ToString());
        return m;
    }

    protected MEMBERS.SQLReturnValue ExecuteProceduerWithValue(string ProceduerName, object[,] paramvalue)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = ProceduerName;
        SqlConnection conn = new SqlConnection(con.ConnectionString);
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter[] param = new SqlParameter[paramvalue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + paramvalue[i, 0].ToString(), paramvalue[i, 1].ToString());
        }
        cmd.Parameters.AddRange(param);

        cmd.Parameters.Add("OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;

        if (conn.State != ConnectionState.Open) { conn.Open(); }
        cmd.ExecuteNonQuery();
        conn.Close();
        MEMBERS.SQLReturnValue m = new MEMBERS.SQLReturnValue();
        m.Outval = int.Parse(cmd.Parameters["OUTVAL"].Value.ToString());
        return m;
    }

    public DataTable GetDataUsingQuery(string Query)
    {
        try
        {
            SqlConnection conne = new SqlConnection(con.ConnectionString);
            SqlDataAdapter sa = new SqlDataAdapter(Query, conne);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public DataTable GetDataUsingQuery(string QueryWithParameters, object[,] ParameterValue)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection MYCON = new SqlConnection(con.ConnectionString);
        cmd.Connection = MYCON;
        SqlParameter[] param = new SqlParameter[ParameterValue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + ParameterValue[i, 0].ToString(), ParameterValue[i, 1]);
        }
        cmd.CommandText = QueryWithParameters;
        cmd.Parameters.AddRange(param);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataSet GetDataUsingQueryDS(string QueryWithParameters, object[,] ParameterValue)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection MYCON = new SqlConnection(con.ConnectionString);
        cmd.Connection = MYCON;
        SqlParameter[] param = new SqlParameter[ParameterValue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + ParameterValue[i, 0].ToString(), ParameterValue[i, 1]);
        }
        cmd.CommandText = QueryWithParameters;
        cmd.Parameters.AddRange(param);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dt = new DataSet();
        da.Fill(dt);
        return dt;
    }

    protected SqlCommand ExecuteProcedure(string ProcedureName, SqlParameter[] param, bool AddOutputParameters)
    {
        try
        {
            SqlCommand COMMAND = new SqlCommand();
            COMMAND.CommandText = ProcedureName;
            SqlConnection MYCON = new SqlConnection(con.ConnectionString);
            COMMAND.Connection = MYCON;
            COMMAND.CommandType = CommandType.StoredProcedure;
            COMMAND.Parameters.AddRange(param);
            if (AddOutputParameters == true)
            {
                COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                COMMAND.Parameters.Add("@OUTMSG", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            }
            if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
            COMMAND.ExecuteNonQuery();
            MYCON.Close();
            return COMMAND;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected DataTable ExecuteProcedure(string ProcedureName, object[,] param)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(ExecuteProceduer(ProcedureName, param, false));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected DataTable ExecuteProcedure(string ProcedureName, SqlParameter[] param)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(ExecuteProcedure(ProcedureName, param, false));
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected DataSet ExecuteProcedureDS(string ProcedureName, SqlParameter[] param)
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(ExecuteProcedure(ProcedureName, param, false));
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //------------------------------------Parameter With Datatable----------------------------------------------
    protected MEMBERS.SQLReturnMessageNValue ExecuteProcedureWithDatatable(string ProcedureName, object[,] ParamValue, DataTable dtExamAnswer, string TableParamName)
    {
        SqlCommand COMMAND = new SqlCommand();
        COMMAND.CommandText = ProcedureName;
        SqlConnection MYCON = new SqlConnection(con.ConnectionString);
        COMMAND.Connection = MYCON;
        COMMAND.CommandTimeout = 0;
        COMMAND.CommandType = CommandType.StoredProcedure;
        SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
        }
        COMMAND.Parameters.AddRange(param);
        if (dtExamAnswer != null)
        {
            SqlParameter ParamTb = new SqlParameter("@" + TableParamName, dtExamAnswer);
            ParamTb.SqlDbType = SqlDbType.Structured;
            COMMAND.Parameters.Add(ParamTb);
        }


        COMMAND.Parameters.Add("OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
        COMMAND.Parameters.Add("OUTMSG", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;

        if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
        COMMAND.ExecuteNonQuery();
        MYCON.Close();
        MEMBERS.SQLReturnMessageNValue m = new MEMBERS.SQLReturnMessageNValue();
        m.Outmsg = COMMAND.Parameters["OUTMSG"].Value.ToString();
        m.Outval = int.Parse(COMMAND.Parameters["OUTVAL"].Value.ToString());
        return m;


    }

    public DataTable PaggingData(Int32 PageNo, Int32 PageSize, ref Int32 TotalRecords, string ProcedureName, object[,] ParamValue)
    {
        SqlConnection MYCON = new SqlConnection(con.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = ProcedureName;
        cmd.Connection = MYCON;

        cmd.Parameters.AddWithValue("@PageIndex", PageNo);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);

        SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
        }
        cmd.Parameters.AddRange(param);

        cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;

        if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
        SqlDataAdapter dGet = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        dGet.Fill(dt);
        TotalRecords = int.Parse(cmd.Parameters["@RecordCount"].Value.ToString());
        MYCON.Close();
        return dt;
    }

    public DataSet PaggingDataDS(Int32 PageNo, Int32 PageSize, ref Int32 TotalRecords, string ProcedureName, object[,] ParamValue)
    {
        SqlConnection MYCON = new SqlConnection(con.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = ProcedureName;
        cmd.Connection = MYCON;

        cmd.Parameters.AddWithValue("@PageIndex", PageNo);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);

        SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
        for (int i = 0; i < param.Length; i++)
        {
            param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
        }
        cmd.Parameters.AddRange(param);

        cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;

        if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
        SqlDataAdapter dGet = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dGet.Fill(ds);
        TotalRecords = int.Parse(cmd.Parameters["@RecordCount"].Value.ToString());
        MYCON.Close();
        return ds;
    }
}
