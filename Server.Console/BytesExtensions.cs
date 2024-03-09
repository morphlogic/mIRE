namespace mIRE.Server.Console
{
    internal static class BytesExtensions
    {
        internal static string ToString(this byte[] bytes, int length) =>
            System.Text.Encoding.ASCII.GetString(bytes, 0, length);
    }
}