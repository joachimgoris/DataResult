namespace DataResult;

/// <summary>
///     Class that represents an error in <see cref="DataResult">.
/// </summary>
public class DataError
{
    /// <summary>
    ///     Gets or sets the code to identify the error.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///     Gets or sets the description of the error.
    /// </summary>
    public string Description { get; set; }
}