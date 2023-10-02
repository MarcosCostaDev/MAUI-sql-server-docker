using Dapper;
using System.Data;
using TodoMaui.Models;

namespace TodoMaui.Repositories;

public class TodoRepository
{
    private readonly IDbConnection _dbConnection;

    public TodoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public void Add(string item)
    {
        try
        {
            _dbConnection.Execute("INSERT INTO TODO (TASK) VALUES (@task)", new
            {
                task = item
            });

        }
        catch (Exception ex)
        {

            throw;
        }
        finally { _dbConnection.Close(); }
    }

    public IEnumerable<TaskItemModel> List()
    {
        try
        {
            return _dbConnection.Query<TaskItemModel>("Select * from TODO");
        }
        catch (Exception)
        {

            throw;
        }
        finally { _dbConnection.Close(); }
    }

    public bool Update(int id, string task)
    {
        try
        {
            return _dbConnection.Execute("UPDATE TODO SET Task = @task, UPDATEDDATE = CURRENT_TIMESTAMP WHERE ID = @ID", new { id, task }) > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally { _dbConnection.Close(); }
    }

    public bool Done(int id)
    {
        try
        {
            return _dbConnection.Execute("UPDATE TODO SET DONE = 1, UPDATEDDATE = CURRENT_TIMESTAMP WHERE ID = @ID", new { id }) > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally { _dbConnection.Close(); }
    }

    public bool Undone(int id)
    {
        try
        {
            return _dbConnection.Execute("UPDATE TODO SET DONE = 0, UPDATEDDATE = CURRENT_TIMESTAMP  WHERE ID = @ID", new { id }) > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally { _dbConnection.Close(); }
    }

    public bool Remove(int id)
    {
        try
        {
            return _dbConnection.Execute("DELETE FROM TODO WHERE ID = @ID", new { id }) > 0;
        }
        catch (Exception)
        {

            throw;
        }
        finally { _dbConnection.Close(); }
    }
}
