namespace HavenLau.Consul.Server
{
    internal class OpenApiOperationDescription
    {
        public string Path { get; set; }
        public string Method { get; set; }
        public object Operation { get; set; }
    }
}