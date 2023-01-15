
namespace TodoMinApi.Infrastructure.Enums
{
    #region Enums

    public enum DomainState
    {
        //
        // Summary:
        //     The domain is not being tracked by the context.
        Detached = 0,
        //
        // Summary:
        //     The domain is being tracked by the context and exists in the database. Its property
        //     values have not changed from the values in the database.
        Unchanged = 1,
        //
        // Summary:
        //     The domain is being tracked by the context and exists in the database. It has
        //     been marked for deletion from the database.
        Deleted = 2,
        // Summary:
        //     The domain is being tracked by the context and exists in the database. Some or
        //     all of its property values have been modified.
        Modified = 3,
        // Summary:
        //     The domain is being tracked by the context but does not yet exist in the database.
        Added = 4
    }

    #endregion
}
