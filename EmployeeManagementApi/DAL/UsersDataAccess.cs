namespace EmployeeManagementApi.DAL;
using MySql.Data.MySqlClient;
using EmployeeManagementApi.Model;
using System.Data;


public class UsersDataAccess
{


    public static string constring = @"server=localhost;port=3306;user=root;password=jayesh@974;database=empinfo";

    public static List<Employee> getAllEmployee()
    {

        List<Employee> emps = new List<Employee>();

        MySqlConnection con = new MySqlConnection(constring);

        try
        {

            string querry = "select * from emp";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(querry, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;

            foreach (DataRow row in rows)
            {
                Employee emp = new Employee
                {
                    empid = int.Parse(row["empid"].ToString()),
                    empname = row["empname"].ToString(),
                    dept = row["dept"].ToString(),
                    joindate = row["joindate"].ToString()
                };
                //  Console.WriteLine(emp);
                emps.Add(emp);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return emps;
    }


    public static Employee getEmployeeById(int id)
    {

        Employee emp = null;
        MySqlConnection con = new MySqlConnection(constring);

        try
        {
            con.Open();
            string querry = "select * from emp where empid =" + id;
            MySqlCommand cmd = new MySqlCommand(querry, con);
            // MySqlDataAdapter ad = new MySqlDataAdapter();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                emp = new Employee
                {
                    empid = int.Parse(reader["empid"].ToString()),
                    empname = reader["empname"].ToString(),
                    dept = reader["dept"].ToString(),
                    joindate = reader["joindate"].ToString()
                };
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return emp;
    }

    public static void insertNewEmp(Employee employee)
    {

        MySqlConnection con = new MySqlConnection(constring);

        try
        {
            con.Open();
            string query = $"insert into emp (empname, dept, joindate) values('{employee.empname}','{employee.dept}','{employee.joindate}')";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteReader();
            // con.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void deleteEmp(int id)
    {

        MySqlConnection con = new MySqlConnection(constring);

        try
        {
            con.Open();
            string query = "delete from emp where empid =" + id;
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteReader();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void updateEmp(int id, Employee employee)
    {

        MySqlConnection con = new MySqlConnection(constring);

        try
        {
            con.Open();
            // string query = $"update emp set empname=" + employee.empname + ", dept=" + employee.dept + " joindate=" + employee.joindate + " where empid=" + id;
            string query = $"update emp set empname='{employee.empname}', dept='{employee.dept}', joindate='{employee.joindate}' where empid={id}";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteReader();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

}