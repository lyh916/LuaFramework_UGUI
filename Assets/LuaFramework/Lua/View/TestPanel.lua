--Find,GetComponent

TestPanel = {};
local this = TestPanel;
 
local gameObject;
local transform;
local luaBehaviour;

--由LuaBehaviour自动调用
function TestPanel.Awake(obj)
	gameObject = obj;
	transform = obj.transform;
	luaBehaviour = transform:GetComponent('LuaBehaviour');

	this.btn = transform:Find("BG/Button"):GetComponent("Button");
	luaBehaviour:AddClick(this.btn.gameObject, function ()
		logWarn("click!!!");
	end);
end
 
--由LuaBehaviour自动调用
function TestPanel.Start()
end