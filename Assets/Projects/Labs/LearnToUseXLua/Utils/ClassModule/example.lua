
local Cat = {}
Cat.HP = 100
function Cat:Ctor()
    self.color = "white"
end
function Cat:Meow() 
    print(string.format("Meow! My color is %s", self.color)) 
end
SetClassMt(Cat)

local cat1 = Cat()
cat1:Meow()
