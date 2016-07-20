(function (lib, img, cjs, ss) {

var p; // shortcut to reference prototypes

// library properties:
lib.properties = {
	width: 1920,
	height: 1080,
	fps: 12,
	color: "#FFFFFF",
	manifest: []
};



// symbols:



(lib.arrow = function() {
	this.spriteSheet = ss["layout_atlas_"];
	this.gotoAndStop(0);
}).prototype = p = new cjs.Sprite();



(lib.cancel = function() {
	this.spriteSheet = ss["layout_atlas_"];
	this.gotoAndStop(1);
}).prototype = p = new cjs.Sprite();



(lib.비트맵1 = function() {
	this.spriteSheet = ss["layout_atlas_"];
	this.gotoAndStop(2);
}).prototype = p = new cjs.Sprite();



(lib.move = function() {
	this.spriteSheet = ss["layout_atlas_"];
	this.gotoAndStop(3);
}).prototype = p = new cjs.Sprite();



(lib.timer = function() {
	this.spriteSheet = ss["layout_atlas_"];
	this.gotoAndStop(4);
}).prototype = p = new cjs.Sprite();



(lib.심볼10 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#C0C0C0").s().p("EDzpBUYMColiovMAsIAAAMiojCovgECcJBUYMColiovMAsIAAAMiojCovgEBEpBUYMColiovMAsIAAAMiojCovgEgS1BUYMCojiovMAsIAAAMiojCovgEhqVBUYMCojiovMAsIAAAMiohCovgEjB1BUYMColiovMAsGAAAMiohCovgEkZVBUYMColiovMAsIAAAMiojCovgElw1BUYMColiovMAsIAAAMiojCovgEnIVBUYMColiovMAsIAAAMiojCovg");

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-2920.6,-540,5841.3,1080);


(lib.Box_Selected = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(5,1,1).p("AmAnzIMBAAQBzAAAABzIAAMBQAABzhzAAIsBAAQhzAAAAhzIAAsBQAAhzBzAAg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(255,18,18,0.749)").s().p("AmAH0QhygBgBhyIAAsBQABhyBygBIMBAAQByABABByIAAMBQgBByhyABg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.Box_Empty = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.instance = new lib.arrow();
	this.instance.setTransform(-32,33,0.333,0.333,-90);

	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(5,1,1).p("AmAnzIMBAAQBzAAAABzIAAMBQAABzhzAAIsBAAQhzAAAAhzIAAsBQAAhzBzAAg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(204,204,204,0.749)").s().p("AmAH0QhygBgBhyIAAsBQABhyBygBIMBAAQByABABByIAAMBQgBByhyABg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape},{t:this.instance}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.Box_change = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(5,1,1).p("AmAnzIMBAAQBzAAAABzIAAMBQAABzhzAAIsBAAQhzAAAAhzIAAsBQAAhzBzAAg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#00CCCC").s().p("AmAH0QhygBgBhyIAAsBQABhyBygBIMBAAQByABABByIAAMBQgBByhyABg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.Box_Cancel = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.instance = new lib.cancel();
	this.instance.setTransform(-32,-32,0.333,0.333);

	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(5,1,1).p("AmAnzIMBAAQBzAAAABzIAAMBQAABzhzAAIsBAAQhzAAAAhzIAAsBQAAhzBzAAg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,102,102,0.749)").s().p("AmAH0QhygBgBhyIAAsBQABhyBygBIMBAAQByABABByIAAMBQgBByhyABg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape},{t:this.instance}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.Box = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f().s("#000000").ss(5,1,1).p("AmAnzIMBAAQBzAAAABzIAAMBQAABzhzAAIsBAAQhzAAAAhzIAAsBQAAhzBzAAg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(0,170,255,0.749)").s().p("AmAH0QhygBgBhyIAAsBQABhyBygBIMBAAQByABABByIAAMBQgBByhyABg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_1},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼8 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 2
	this.instance = new lib.심볼10();
	this.instance.setTransform(1000.6,0);

	this.timeline.addTween(cjs.Tween.get(this.instance).to({x:-650},49).wait(1));

	// 레이어 1
	this.instance_1 = new lib.비트맵1();
	this.instance_1.setTransform(-960,-540);

	this.timeline.addTween(cjs.Tween.get(this.instance_1).wait(50));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-1920,-540,5841.3,1080);


(lib.심볼7 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AhGDbQgEAAgDgCQgBgDACgEICcmEIjDAAQgKAAABgJIAAgWQgBgJAKAAIDfAAQANAAADACQACACAAAOIAAAQQAAAFgCAEIiWGBQgEAJgJAAg");
	this.shape.setTransform(-0.1,0.3);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼6 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AhTC4Qgwg1AAh0QAAhoAvhBQA2hGBNAAQAMAAAQACQARADAPADQAJACgBAJIgBAZQAAAFgEACQgDABgDgBQgOgGgOgCQgPgDgNgBQg+ABgnA5QghAygCBPQANgWAVgRQAcgWAjAAQArAAAhAdQAvAnAABGQAAA9gmAqQgmArgzAAQgxAAgngpgAgZgLQgRAIgMAOQgMARgFASQgGASAAASQAAAkASAdQAZAnAnAAQAoAAAagnQARgdAAgkQABglgSgdQgagjgoABIgEgBQgLAAgPAIg");
	this.shape.setTransform(-0.1,0.1);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼5 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AhFDaQgUgCgWgJQgIgDAAgIIAAgbQAAgLAIAEQAXALASAFQASAEATAAQAoAAAigbQAjgeABgsQAAhghoAAQgOAAgRADQgRACgXAIQgHACgEgDQgFgEAAgHIAEi8QAAgOACgCQADgCAMAAIC4AAQAIAAAAAJIAAAVQAAAJgIAAIifAAIgBBGIgCBEQAcgKAhAAQAyAAAnAiQApAjAAA3QAABDguAsQgwAng7AAQgRAAgTgDg");
	this.shape.setTransform(0.9,0.5);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼4_selected = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AAiDbQgJAAAAgJIAAhnIiaAAQgNAAgCgDQgDgCAAgNIAAgVIABgHIAEgHICTkIIAFgHQACgBAHAAIAgAAQANAAADACQACACAAAOIAAELIBGAAQAJABAAAIIAAAWQAAAIgJABIhGAAIAABnQAAAJgJAAgAhqBDICDAAIAAjug");
	this.shape.setTransform(0.4,0.3);

	this.instance = new lib.Box_Selected("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼4 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AAiDbQgJAAAAgJIAAhnIiaAAQgNAAgCgDQgDgCAAgNIAAgVIABgHIAEgHICTkIIAFgHQACgBAHAAIAgAAQANAAADACQACACAAAOIAAELIBGAAQAJABAAAIIAAAWQAAAIgJABIhGAAIAABnQAAAJgJAAgAhqBDICDAAIAAjug");
	this.shape.setTransform(0.4,0.3);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼3change = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AhHDcQgYgDgZgJQgJgDABgMIADgXQABgIAJAEQAUAJAWAFQAXAFAWAAQAsAAAdgWQAngbAAgsQgBhSh/AAIgNAAQgIAAAAgIIAAgVQAAgIAIAAIADAAQAqAAAkgPQA5gXAAgwQAAgSgJgOQgJgOgSgJQgMgHgRgFQgQgEgUAAQgUAAgUAGQgUAGgSAJQgHAEgCgJIgCgXQgCgJAJgEQAVgJAWgFQAWgFAVAAQA2AAArAbQAsAgAAAzQAAAogcAbQgbAagoAKQARACAUAIQAUAKAMANQAPAQAHASQAIASAAAUQAAAcgMAXQgLAYgYASQgYASgbAJQgbAJgeAAQgVAAgYgEg");
	this.shape.setTransform(0.6,0.2);

	this.instance = new lib.Box_change("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼3 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AhHDcQgYgDgZgJQgJgDABgMIADgXQABgIAJAEQAUAJAWAFQAXAFAWAAQAsAAAdgWQAngbAAgsQgBhSh/AAIgNAAQgIAAAAgIIAAgVQAAgIAIAAIADAAQAqAAAkgPQA5gXAAgwQAAgSgJgOQgJgOgSgJQgMgHgRgFQgQgEgUAAQgUAAgUAGQgUAGgSAJQgHAEgCgJIgCgXQgCgJAJgEQAVgJAWgFQAWgFAVAAQA2AAArAbQAsAgAAAzQAAAogcAbQgbAagoAKQARACAUAIQAUAKAMANQAPAQAHASQAIASAAAUQAAAcgMAXQgLAYgYASQgYASgbAJQgbAJgeAAQgVAAgYgEg");
	this.shape.setTransform(0.6,0.2);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼2 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AhxDeIgJgBQgEAAgCgCQgBgBgBgDIAAgLIAAgPQAAgIAFgEIBhhkQBlhsgBg9QABgqgTgXQgWgYglgBQgtAAguAdQgJAEgCgIIgEgWQgCgKAJgEQAZgNAYgIQAYgGAZgBQAxAAAlAfQAoAiAAA9QAAAXgLAdQgLAcgXAfIglAtIglApIglApIgmAnIDEAAQAJAAAAAJIAAAXQAAAHgJABg");
	this.shape.setTransform(-0.3,0);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


(lib.심볼1 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// 레이어 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#070707").s().p("AAlDbQgJAAAAgJIAAl4IgjAgIglAfQgHAGgFgHIgNgQQgCgDAAgDQAAgDADgDIBhhTQADgDAFAAIARAAQAOAAACACQACACAAAOIAAGaQAAAJgJAAg");
	this.shape.setTransform(-3.1,0.3);

	this.instance = new lib.Box("synched",0);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance},{t:this.shape}]}).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-52.5,-52.5,105,105);


// stage content:
(lib.layout = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_0 = function() {
		stop();
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(56));

	// text
	this.instance = new lib.timer();
	this.instance.setTransform(1240.5,730,0.333,0.333);

	this.instance_1 = new lib.move();
	this.instance_1.setTransform(540,730,0.333,0.333);

	this.shape = new cjs.Shape();
	this.shape.graphics.f("#424242").s().p("AhADTQgagTgQghQgPgggGgqQgHgpAAgsQAAgkAGgoQAFgpAPgiQAPgiAagWQAagWApAAQAoAAAaAVQAZAUAQAgQAOAhAHAqQAGApABAoQAAAlgFAoQgGApgPAiQgOAigbAWQgbAXgpgBIgDAAQgkAAgZgTgAgui3QgSATgLAcQgLAegEAkQgEAkAAAiQAAAjAEAlQADAjALAeQALAcASASQASASAdAAQAcAAATgSQASgRALgdQAKgdAEgkQAEgkAAgkQAAgigEgkQgEgkgKgdQgLgdgSgTQgTgSgcAAQgbAAgTASg");
	this.shape.setTransform(1447,761);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#424242").s().p("AhADTQgagTgQghQgPgggGgqQgHgpAAgsQAAgkAGgoQAFgpAPgiQAPgiAagWQAagWApAAQAoAAAaAVQAZAUAQAgQAOAhAHAqQAGApABAoQAAAlgFAoQgGApgPAiQgOAigbAWQgbAXgpgBIgDAAQgkAAgZgTgAgui3QgSATgLAcQgLAegEAkQgEAkAAAiQAAAjAEAlQADAjALAeQALAcASASQASASAdAAQAcAAATgSQASgRALgdQAKgdAEgkQAEgkAAgkQAAgigEgkQgEgkgKgdQgLgdgSgTQgTgSgcAAQgbAAgTASg");
	this.shape_1.setTransform(1415,761);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#424242").s().p("AgbCbIAAg7IA3AAIAAA7gAgbhfIAAg7IA3AAIAAA7g");
	this.shape_2.setTransform(1390.9,763.2);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#424242").s().p("AhADTQgagTgQghQgPgggGgqQgHgpAAgsQAAgkAGgoQAFgpAPgiQAPgiAagWQAagWApAAQAoAAAaAVQAZAUAQAgQAOAhAHAqQAGApABAoQAAAlgFAoQgGApgPAiQgOAigbAWQgbAXgpgBIgDAAQgkAAgZgTgAgui3QgSATgLAcQgLAegEAkQgEAkAAAiQAAAjAEAlQADAjALAeQALAcASASQASASAdAAQAcAAATgSQASgRALgdQAKgdAEgkQAEgkAAgkQAAgigEgkQgEgkgKgdQgLgdgSgTQgTgSgcAAQgbAAgTASg");
	this.shape_3.setTransform(1366,761);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f("#424242").s().p("AhADTQgagTgQghQgPgggGgqQgHgpAAgsQAAgkAGgoQAFgpAPgiQAPgiAagWQAagWApAAQAoAAAaAVQAZAUAQAgQAOAhAHAqQAGApABAoQAAAlgFAoQgGApgPAiQgOAigbAWQgbAXgpgBIgDAAQgkAAgZgTgAgui3QgSATgLAcQgLAegEAkQgEAkAAAiQAAAjAEAlQADAjALAeQALAcASASQASASAdAAQAcAAATgSQASgRALgdQAKgdAEgkQAEgkAAgkQAAgigEgkQgEgkgKgdQgLgdgSgTQgTgSgcAAQgbAAgTASg");
	this.shape_4.setTransform(1334,761);

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.f("#424242").s().p("AAUDiIAAmhIhOAyIAAgfIBQg0IAlAAIAAHCg");
	this.shape_5.setTransform(667.3,760.7);

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.f("#424242").s().p("AhADTQgagTgQghQgPgggGgqQgHgpAAgsQAAgkAGgoQAFgpAPgiQAPgiAagWQAagWApAAQAoAAAaAVQAZAUAQAgQAOAhAHAqQAGApABAoQAAAlgFAoQgGApgPAiQgOAigbAWQgbAXgpgBIgDAAQgkAAgZgTgAgui3QgSATgLAcQgLAegEAkQgEAkAAAiQAAAjAEAlQADAjALAeQALAcASASQASASAdAAQAcAAATgSQASgRALgdQAKgdAEgkQAEgkAAgkQAAgigEgkQgEgkgKgdQgLgdgSgTQgTgSgcAAQgbAAgTASg");
	this.shape_6.setTransform(638,761);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_6},{t:this.shape_5},{t:this.shape_4},{t:this.shape_3},{t:this.shape_2},{t:this.shape_1},{t:this.shape},{t:this.instance_1},{t:this.instance}]}).to({state:[]},6).wait(50));

	// playground
	this.instance_2 = new lib.심볼7("synched",0);
	this.instance_2.setTransform(1316,510);

	this.instance_3 = new lib.심볼1("synched",0);
	this.instance_3.setTransform(1216,510);

	this.instance_4 = new lib.심볼5("synched",0);
	this.instance_4.setTransform(1116,510);

	this.instance_5 = new lib.심볼3("synched",0);
	this.instance_5.setTransform(1016,510);

	this.instance_6 = new lib.심볼4("synched",0);
	this.instance_6.setTransform(916,510);

	this.instance_7 = new lib.심볼2("synched",0);
	this.instance_7.setTransform(816,510);

	this.instance_8 = new lib.심볼6("synched",0);
	this.instance_8.setTransform(716,510);

	this.instance_9 = new lib.심볼4_selected("synched",0);
	this.instance_9.setTransform(392,242);

	this.instance_10 = new lib.Box_Empty("synched",0);
	this.instance_10.setTransform(922.5,352.5,0.75,0.75);

	this.instance_11 = new lib.Box_Empty("synched",0);
	this.instance_11.setTransform(825.5,352.5,0.75,0.75);

	this.instance_12 = new lib.Box_Empty("synched",0);
	this.instance_12.setTransform(692.5,352.5,0.75,0.75);

	this.instance_13 = new lib.Box_Empty("synched",0);
	this.instance_13.setTransform(558.5,352.5,0.75,0.75);

	this.instance_14 = new lib.Box_Empty("synched",0);
	this.instance_14.setTransform(44.5,352.5,0.75,0.75);

	this.instance_15 = new lib.Box_Cancel("synched",0);
	this.instance_15.setTransform(360,365);

	this.instance_16 = new lib.Box_Empty("synched",0);
	this.instance_16.setTransform(160,352.5,0.75,0.75);

	this.instance_17 = new lib.심볼3change("synched",0);
	this.instance_17.setTransform(492,242);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_8,p:{x:716,y:510}},{t:this.instance_7,p:{x:816,y:510}},{t:this.instance_6,p:{x:916,y:510}},{t:this.instance_5,p:{x:1016,y:510}},{t:this.instance_4,p:{x:1116,y:510}},{t:this.instance_3,p:{x:1216,y:510}},{t:this.instance_2,p:{x:1316,y:510}}]}).to({state:[{t:this.instance_8,p:{x:192,y:242}},{t:this.instance_7,p:{x:292,y:242}},{t:this.instance_5,p:{x:492,y:242}},{t:this.instance_4,p:{x:592,y:242}},{t:this.instance_3,p:{x:692,y:242}},{t:this.instance_2,p:{x:792,y:242}},{t:this.instance_9,p:{x:392}}]},1).to({state:[{t:this.instance_8,p:{x:96,y:242}},{t:this.instance_7,p:{x:228,y:242}},{t:this.instance_5,p:{x:492,y:242}},{t:this.instance_4,p:{x:624,y:242}},{t:this.instance_3,p:{x:756,y:242}},{t:this.instance_2,p:{x:888,y:242}},{t:this.instance_9,p:{x:360}},{t:this.instance_16},{t:this.instance_15},{t:this.instance_14},{t:this.instance_13},{t:this.instance_12},{t:this.instance_11},{t:this.instance_10}]},1).to({state:[{t:this.instance_8,p:{x:96,y:242}},{t:this.instance_7,p:{x:228,y:242}},{t:this.instance_4,p:{x:624,y:242}},{t:this.instance_3,p:{x:756,y:242}},{t:this.instance_2,p:{x:888,y:242}},{t:this.instance_9,p:{x:360}},{t:this.instance_17,p:{x:492}}]},1).to({state:[{t:this.instance_8,p:{x:96,y:242}},{t:this.instance_7,p:{x:228,y:242}},{t:this.instance_4,p:{x:624,y:242}},{t:this.instance_3,p:{x:756,y:242}},{t:this.instance_2,p:{x:888,y:242}},{t:this.instance_9,p:{x:492}},{t:this.instance_17,p:{x:360}}]},1).to({state:[{t:this.instance_8,p:{x:192,y:242}},{t:this.instance_7,p:{x:292,y:242}},{t:this.instance_6,p:{x:492,y:242}},{t:this.instance_5,p:{x:392,y:242}},{t:this.instance_4,p:{x:592,y:242}},{t:this.instance_3,p:{x:692,y:242}},{t:this.instance_2,p:{x:792,y:242}}]},1).to({state:[]},1).wait(50));

	// background
	this.instance_18 = new lib.심볼8("synched",0);
	this.instance_18.setTransform(960,540);

	this.timeline.addTween(cjs.Tween.get(this.instance_18).wait(56));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-0.2,540,5841.7,1080);

})(lib = lib||{}, images = images||{}, createjs = createjs||{}, ss = ss||{});
var lib, images, createjs, ss;