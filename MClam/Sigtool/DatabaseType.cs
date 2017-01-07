namespace MClam.Sigtool
{
    /// <summary>
    /// Specified ClamAV database type (according to sigtool specs).
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// Clamav Database File (CVD).
        /// </summary>
        Clamav,

        /// <summary>
        /// MD5 hash database.
        /// </summary>
        Md5Hash,

        /// <summary>
        /// SHA1 and SHA256 hash database.
        /// </summary>
        ShaHash,

        /// <summary>
        /// Pe section hash database.
        /// </summary>
        PeSectionHash,

        /// <summary>
        /// Unknown database type.
        /// </summary>
        Unknown
    }
}
