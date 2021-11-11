namespace BlazorBeast.Shared.Rendering;

public abstract record RenderLocation;
public sealed record RenderedOnServer : RenderLocation;
public sealed record RenderedOnClient : RenderLocation;