TestCtrl = {};
local this = TestCtrl;

function TestCtrl.New()
	return this;
end
 
function TestCtrl.Awake()
	panelMgr:CreatePanel("Prefab/Test","TestPanel");
end