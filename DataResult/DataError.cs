namespace DataResult;

/// <summary>
///     Class that represents an error in <see cref="DataResult">.
/// </summary>
public class DataError
{
    /// <summary>
    ///     Gets or sets the code to identify the <see cref="DataError"/>.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///     Gets or sets the description of the <see cref="DataError"/>.
    /// </summary>
    public string Description { get; set; }
}
