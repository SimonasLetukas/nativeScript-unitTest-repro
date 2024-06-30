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
        
        if (nativeLibraryExists is false || nativeScriptExists is false)
            throw new Exception("Script file could not be found.");
		
        var dijkstraMapScript = GD.Load("res://addons/dijkstra-map/Dijkstra_map_library/nativescript.gdns") as NativeScript;
        var dijkstraMap = dijkstraMapScript?.New() as Object;
        if (dijkstraMap is null) 
            throw new ArgumentNullException($"{nameof(dijkstraMap)} cannot be null.");
    }
}
