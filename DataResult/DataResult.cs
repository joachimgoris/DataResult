namespace DataResult;

using System.Collections.Generic;
using System.Linq;

/// <summary>
///     An object that is used as a return type. Errors can be added to the object with <see cref="DataError"/>. <see cref="DataResult{TEntity}"/> extends on this to also return entities.
/// </summary>
public class DataResult
{
    /// <summary>
    ///     Constructs a new <see cref="DataResult"/> which is successful.
    /// </summary>
    public static readonly DataResult Success = new()
    {
        Succeeded = true,
    };

    /// <summary>
    ///     The property containing the <see cref="DataError"/>
    /// </summary>
    internal ICollection<DataError> Errors = [];

    /// <summary>
    ///     Gets or sets a value indicating whether the <see cref="DataResult"/> is successful.
    /// </summary>
    public bool Succeeded { get; set; }

    /// <summary>
    ///     Constructs a new <see cref="DataResult"/> with a <see cref="DataError"/>.
    /// </summary>
    /// <param name="code">
    ///     The <see cref="DataError.Code"> of the <see cref="DataError"/> object.
    /// </param>
    /// <param name="description">
    ///     The <see cref="DataError.Description"/> of the <see cref="DataError"/> object.
    /// </param>
    /// <returns>
    ///     A new <see cref="DataResult"/> object containing the <see cref="DataError"/>.
    /// </returns>
    public static DataResult WithError(string code, string description)
    {
        return new DataResult
        {
            Errors =
            [
                new() {
                    Code = code,
                    Description = description,
                },
            ],
            Succeeded = false,
        };
    }

    /// <summary>
    ///     Constructs a new <see cref="DataResult"/> containing the <see cref="DataError"/> passed as a parameter.
    /// </summary>
    /// <param name="error">
    ///     The <see cref="DataError"/> object to add to the <see cref="DataResult"/> object.
    /// </param>
    /// <returns>
    ///     A new <see cref="DataResult"/> object containing the <see cref="DataError"/>.
    /// </returns>
    public static DataResult WithError(DataError error)
    {
        return new DataResult
        {
            Errors =
            [
                error,
            ],
            Succeeded = false,
        };
    }

    /// <summary>
    ///     Constructs a new <see cref="DataResult"/> containing a collection of <see cref="DataError"/>'s.
    /// </summary>
    /// <param name="errors">
    ///     The collection of <see cref="DataError"/> to add to the newly constructed <see cref="DataResult"/> object.
    /// </param>
    /// <returns>
    ///     A new <see cref="DataResult"/> object containing the collection of <see cref="DataError"/> in its <see cref="DataResult.Errors"(/>.
    /// </returns>
    public static DataResult WithError(ICollection<DataError> errors)
    {
        return new DataResult
        {
            Errors = errors,
            Succeeded = false,
        };
    }

    /// <summary>
    ///     Adds a new <see cref="DataError"/> to the existing <see cref="DataResult"/>.
    /// </summary>
    /// <param name="code">
    ///     The <see cref="DataError.Code"/> for the <see cref="DataError"/> object.
    /// </param>
    /// <param name="description">
    ///     The <see cref="DataError.Description"/> for the <see cref="DataError"/> object.
    /// </param>
    public void AddError(string code, string description)
    {
        this.Succeeded = false;

        this.Errors.Add(new DataError
        {
            Code = code,
            Description = description,
        });
    }

    /// <summary>
    ///     Returns the collection of <see cref="DataError"/>'s in  a <see cref="DataResult"/> object.
    /// </summary>
    /// <returns>
    ///     The <see cref="ICollection{DataError}"/> inside the <see cref="DataResult"/> object.
    /// </returns>
    public ICollection<DataError> GetErrors()
    {
        return this.Errors;
    }

    /// <summary>
    ///     Checks if a <see cref="DataResult"/> object contains a <see cref="DataError"/> with the given <see cref="DataError.Code"/>.
    /// </summary>
    /// <param name="code">
    ///     The <see cref="DataError.Code"/> on which to check the <see cref="DataError"/>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if there is a <see cref="DataError"/> object with the given <see cref="DataError.Code"/> in the <see cref="DataResult"/>.
    /// </returns>
    public bool HasError(string code)
    {
        return this.Errors.Any(error => error.Code.Equals(code));
    }
}