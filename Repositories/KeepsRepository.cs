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

    // Creates a Keep=
    #region 
    public Keep CreateKeep(Keep keep)
    {
      _db.Execute("INSERT INTO keeps (name, description, img, isprivate, userId) VALUES (@Name, @Description, @Img, @IsPrivate, @UserId)", keep);
      return keep;
    }
    #endregion

    // Get Public Keeps=
    #region 
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }
    #endregion

    // Get Keeps by ID
    #region
    public Keep GetbyKeepId(string id)
    {
      string query = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(query, new { id });
    }
    #endregion


    // Get Keeps By UserId
    #region 
    public IEnumerable<Keep> GetUserKeeps(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId", new { userId });
    }
    #endregion

    // STRETCH GOAL is to do an EDIT

    // Deletes a keep=
    #region 
    public bool DeleteKeep(string keepId)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @keepId", new { keepId });
      return success > 0;
    }
    #endregion

  }
}