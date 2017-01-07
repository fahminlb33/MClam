namespace MClam.Sigtool
{
    /// <summary>
    /// Hash entry.
    /// </summary>
    /// <remarks>When using <see cref="DatabaseType.PeSectionHash"/>, you need to calculate
    /// PE section hash, which can be done by using tools like <c>exeinfope</c>. Open up
    /// the file and use Sections Viewer to select and save it. Use <see cref="Algorithm.MD5"/> 
    /// algorithm to calculate section hash.</remarks>
    public class HashDatabaseEntry
    {
        /// <summary>
        /// File hash.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Hash size.
        /// </summary>
        public int Size { get; set; } = -1;

        /// <summary>
        /// Malware name
        /// </summary>
        public string MalwareName { get; set; }
    }
}
