using System;
using FluentAssertions;
using Godot;
using Xunit;
using Object = Godot.Object;

namespace nativeScript_unitTest_repro_tests
{
    public class GameTests
    {
        [Fact]
        public void Ctor_ShouldFindTheNativeScript_WhenItExistsInTheSolution()
        {
            var dijkstraMapScript = GD.Load("res://addons/dijkstra-map/Dijkstra_map_library/nativescript.gdns") as NativeScript;
            var dijkstraMap = dijkstraMapScript?.New() as Object;
            if (dijkstraMap is null) 
                throw new ArgumentNullException($"{nameof(dijkstraMap)} cannot be null.");
            dijkstraMap.Should().NotBeNull();

            var game = (Game) GD.Load<PackedScene>(Game.ScenePath).Instance();
            game.Should().NotBeNull();
        }
    }
}