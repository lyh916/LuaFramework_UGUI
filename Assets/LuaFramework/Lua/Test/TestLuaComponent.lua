--测试LuaComponent

TestLuaComponent = {
	property1 = 100,
	property2 = "helloWorld",
}

function TestLuaComponent:New()
	local o = {};
	setmetatable(o, self);
	self.__index = self;
	return o;
end

function TestLuaComponent:Awake()
	logWarn("TestLuaComponent Awake:");
end

function TestLuaComponent:Start()
	logWarn("TestLuaComponent Start:");
end

function TestLuaComponent:Update()
	logWarn("TestLuaComponent Update:");
end