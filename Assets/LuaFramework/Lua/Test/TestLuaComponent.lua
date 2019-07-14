--测试LuaComponent

TestLuaComponent = 
{
	tableName = "TestLuaComponent",
	property1 = 100,
}

function TestLuaComponent:New()
	local o = {};
	setmetatable(o, self);
	self.__index = self;
	return o;
end

function TestLuaComponent:Awake(go)
	self.go = go;
	logWarn("TestLuaComponent Awake:" .. go.name .. "_" .. self.property1);
end

function TestLuaComponent:Start(go)
	logWarn("TestLuaComponent Start:" .. go.name .. "_" .. self.property1);
end

function TestLuaComponent:Update()
	logWarn("TestLuaComponent Update:" .. self.go.name);
end