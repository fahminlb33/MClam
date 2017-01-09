namespace MClam.Sigtool
{
    /// <summary>
    /// Specifies database counting option.
    /// </summary>
    public enum CountOption
    {
        /// <summary>
        /// Count official database only.
        /// </summary>
        Official = 0x01,

        /// <summary>
        /// Count unofficial database only.
        /// </summary>
        Unofficial = 0x02,

        /// <summary>
        /// Count both official and unofficial database.
        /// </summary>
        All = Official | Unofficial
    }
}
