namespace MClam
{
    /// <summary>
    /// File scan result.
    /// </summary>
    public class ScanResult
    {
        /// <summary>
        /// Virus name (if the file is infected).
        /// </summary>
        public string VirusName { get; internal set; }

        /// <summary>
        /// Fullpath to file has been scanned.
        /// </summary>
        public string FullPath { get; internal set; }

        /// <summary>
        /// Number of bytes that has been scanned.
        /// </summary>
        public int Scanned { get; internal set; }

        /// <summary>
        /// Returns a value indicating this file is infected or not.
        /// </summary>
        public bool IsVirus { get; internal set; }
    }
}
