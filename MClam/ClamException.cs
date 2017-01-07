using System;

namespace MClam
{
    /// <summary>
    /// Exception class for errors from libclamav native.
    /// </summary>
    /// <remarks><para>This class gets the error messages from libclamav using error codes by invoking P/Invoke to libclamav.
    /// This class should not be thrown outside by <c>MClam</c> internals.</para>
    /// <para>See <c>The ClamException and other Exceptions.</c> topic on the <c>Cheatsheet.</c></para>
    /// </remarks>
    public sealed class ClamException : Exception
    {
        internal ClamException(int errorCode) : base(CommonMethods.GetClamErrorText(errorCode))
        { }
    }
}
