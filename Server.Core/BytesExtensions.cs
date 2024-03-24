namespace mIRE.Server.Core
{
    internal static class BytesExtensions
    {
        internal static string ToString(this byte[] bytes, int length) =>
            System.Text.Encoding.ASCII.GetString(bytes, 0, length);
    }
}