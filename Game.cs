using System;
using Godot;
using Object = Godot.Object;

public class Game : Node2D
{
    public const string ScenePath = @"res://Game.tscn";

    public Game()
    {
        var nativeScriptExists = ResourceLoader.Exists("res://addons/dijkstra-map/Dijkstra_map_library/nativescript.gdns");
        var nativeLibraryExists = ResourceLoader.Exists("res://addons/dijkstra-map/Dijkstra_map_library/gdnativelibrary.tres");
		
        GD.Print($"{nameof(nativeScriptExists)} {nativeScriptExists}, {nameof(nativeLibraryExists)} {nativeLibraryExists}");
		
        var dijkstraMapScript = GD.Load("res://addons/dijkstra-map/Dijkstra_map_library/nativescript.gdns") as NativeScript;
        var dijkstraMap = dijkstraMapScript?.New() as Object;
        if (dijkstraMap is null) 
            throw new ArgumentNullException($"{nameof(dijkstraMap)} cannot be null.");
    }
}
