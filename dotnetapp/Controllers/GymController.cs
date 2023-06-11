using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

public class GymController : Controller
{
    // private readonly IRepository<GymMembership> _repository;

    // public GymController(IRepository<GymMembership> repository)
    // {
    //     _repository = repository;
    // }

    private string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=GymDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

    public ActionResult Index()
    {
        // List<GymMembership> gyms = new List<GymMembership>();
    try
    {
        List<GymMembership> gyms = new List<GymMembership>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM GymMembership";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GymMembership gym = new GymMembership();

                    gym.id = Convert.ToInt32(reader["id"]);
                    gym.Name = reader["Name"].ToString();
                    gym.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
                    gym.MembershipType = reader["MembershipType"].ToString();
                    gym.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);

                    gyms.Add(gym);
                }

                reader.Close();
            }
        }
        return View(gyms);

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving the gym item.");

}
        // return View(gyms);

    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(GymMembership gym)
    {
        try{
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO GymMembership (Name, JoiningDate, MembershipType, ExpiryDate) VALUES (@Name, @JoiningDate,@MembershipType, @ExpiryDate)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // command.Parameters.AddWithValue("@id", Book.id);
                command.Parameters.AddWithValue("@Name", gym.Name);
                command.Parameters.AddWithValue("@JoiningDate", gym.JoiningDate);
                command.Parameters.AddWithValue("@MembershipType", gym.MembershipType);
                command.Parameters.AddWithValue("@ExpiryDate", gym.ExpiryDate);
                // command.Parameters.AddWithValue("@Price", gym.Price);


                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        }
        catch(Exception ex)
{
    Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while creating the gym item.");

}

        return RedirectToAction("Index");
    }


    public ActionResult Edit(int id)
{
    try
    {
        GymMembership gym = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM GymMembership WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    gym = new GymMembership();
                    gym.id = Convert.ToInt32(reader["id"]);
                    gym.Name = reader["Name"].ToString();
                    gym.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]);
                    gym.MembershipType = reader["MembershipType"].ToString();
                    gym.ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]);
                }

                reader.Close();
            }
        }

        if (gym == null)
        {
            return NotFound();
        }

        return View(gym);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        // You can handle the exception as per your requirements (e.g., logging, displaying an error message)
        return BadRequest("An error occurred while retrieving the gym item.");
    }
}


    [HttpPost]
    public ActionResult Edit(GymMembership gym)
    {
        try{
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE GymMembership SET Name = @Name, JoiningDate = @JoiningDate, MembershipType = @MembershipType, ExpiryDate = @ExpiryDate WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", gym.id);
                // Console.WriteLine(gym.id);
                command.Parameters.AddWithValue("@Name", gym.Name);
                                // Console.WriteLine(gym.Product);

                command.Parameters.AddWithValue("@JoiningDate", gym.JoiningDate);
                command.Parameters.AddWithValue("@MembershipType", gym.MembershipType);
                command.Parameters.AddWithValue("@ExpiryDate", gym.ExpiryDate);
                // command.Parameters.AddWithValue("@Price", gym.Price);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    // The provided ID does not exist in the GymMembership table
                    return NotFound();
                }
            }
        }}
        catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        try{
            if (id <= 0)
        {
            return BadRequest();
        }
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "DELETE FROM GymMembership WHERE id = @id";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return NotFound();
                }
        }
    }}
    catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    return BadRequest("An error occurred while deleting the gym item.");

}

    return RedirectToAction("Index");
    }


}