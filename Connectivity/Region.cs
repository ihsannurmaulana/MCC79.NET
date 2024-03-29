﻿using System.Data;
using System.Data.SqlClient;

namespace Connectivity
{
    class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //SqlConnection conn = MyConnection.Get();

        // GetAllRegion : Region
        public List<Region> GetAll()
        {

            SqlConnection connection = MyConnection.Get();
            connection.Open();
            var region = new List<Region>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);
                        region.Add(reg); // Menambahkan objek Region ke dalam list
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return region; // Mengembalikan list regions yang berisi objek-objek Region
        }

        // GetRegionByID
        public List<Region> GetByID(int id)
        {

            SqlConnection connection = MyConnection.Get();
            connection.Open();
            var region = new List<Region>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Region();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);
                        region.Add(reg); // Menambahkan objek Region ke dalam list
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            connection.Close();
            return region; // Mengembalikan list regions yang berisi objek-objek Region
        }

        // Insert Region : Region
        public int Insert(string name)
        {
            int result = 0;

            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                // Menambahkan parameter ke command
                command.Parameters.Add(pName);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            connection.Close();
            return result;

        }

        // Update Region : Region
        public int Update(int id, string newName)
        {
            int result = 0;

            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_regions SET name = @newName WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@newName";
                pNewName.Value = newName;
                pNewName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;

                // Menambahkan parameter ke command
                command.Parameters.Add(pNewName);
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            connection.Close();
            return result;
        }

        // Delete Region : Region
        public int Delete(int id)
        {
            int result = 0;

            SqlConnection connection = MyConnection.Get();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_regions WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            connection.Close();
            return result;
        }

        // Menu 
        // Show Menu GetByID Region
        public void MenuGetByID()
        {
            Console.WriteLine("     GetRegionByID      ");
            Console.WriteLine("------------------------");
            Console.Write("Select region By ID : ");
            int id = int.Parse(Console.ReadLine());
            List<Region> regions = GetByID(id);
            foreach (Region region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name : " + region.Name);
            }
            Console.ReadKey();
            //RegionMenu();
        }

        // Menu Insert Region
        public void InsertMenu()
        {
            Console.WriteLine("      Insert      ");
            Console.WriteLine("----------------- ");
            Console.Write("Add new name region : ");
            string name = Console.ReadLine();
            int isInsertSuccessful = Insert(name);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Data added successfully");
            }
            else
            {
                Console.WriteLine("Data failed to add");
            }
            Console.ReadKey();
            //RegionMenu();
        }

        // Menu Update Region 
        public void UpdateMenu()
        {
            Console.WriteLine("     Update Region       ");
            Console.WriteLine("-------------------------");
            Console.Write("Input ID of the region to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Input the new name for the region: ");
            string newName = Console.ReadLine();

            int updateResult = Update(id, newName);
            if (updateResult > 0)
            {
                Console.WriteLine("Data updated successfully");
            }
            else
            {
                Console.WriteLine("Failed to update data");
            }
            Console.ReadKey();
            //RegionMenu();
        }

        // Menu Delete Region
        public void DeleteMenu()
        {
            Console.WriteLine("           Delete Region          ");
            Console.WriteLine("----------------------------------");
            Console.Write("Input the ID of the region to delete: ");
            int id = int.Parse(Console.ReadLine());

            int deleteResult = Delete(id);
            if (deleteResult > 0)
            {
                Console.WriteLine("Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete data");
            }
            Console.ReadKey();
            //RegionMenu()
        }

        // Menu All Region
        public void Menu()
        {

            bool isFinish = true;
            do
            {
                // GetALl Rgeion : Region
                Console.Clear();
                Console.WriteLine("       GetAll Region      ");
                Console.WriteLine("--------------------------");
                List<Region> regions = GetAll();
                foreach (Region region in regions)
                {
                    Console.WriteLine("Id : " + region.Id + ", Name : " + region.Name);
                }

                Console.WriteLine("\n");
                Console.WriteLine("     Menu     ");
                Console.WriteLine("--------------");
                Console.WriteLine("1. GetById");
                Console.WriteLine("2. Insert");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Exit");

                try
                {
                    Console.Write("Select Menu : ");
                    int InputPilihan = int.Parse(Console.ReadLine());

                    switch (InputPilihan)
                    {
                        case 1:
                            MenuGetByID();
                            break;
                        case 2:
                            InsertMenu();
                            break;
                        case 3:
                            UpdateMenu();
                            break;
                        case 4:
                            DeleteMenu();
                            break;
                        case 5:
                            isFinish = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (isFinish);

        }
    }

}
