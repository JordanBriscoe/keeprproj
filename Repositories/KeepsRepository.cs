using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    // Get Public Keeps
    #region 
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }
    #endregion

    // Get Keeps by  KeepID
    #region
    public Keep GetbyId(string id)
    {
      string query = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(query, new { id });
    }
    #endregion

    // STRETCH GOAL is to do an EDIT

    // Creates a Keep
    #region 
    public Keep CreateKeep(Keep keep)
    {
      _db.Execute("INSERT INTO keeps (name, description, img, isprivate, userId) VALUES (@Name, @Description, @Img, @IsPrivate, @UserId)", keep);
      return keep;
    }
    #endregion

    // Deletes a keep
    #region 
    public bool DeleteKeep(string keepId)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @keepId", new { keepId });
      return success > 0;
    }
    #endregion

  }
}