#get info such as wall dimensions and paint type
wallOne = input("length of wall one: ")
wallTwo = input("length of wall two: ")
height = input("height of room: ")
undercoat = input("undercoat? yes/no: ")

#turn undercoat into a boolean
if undercoat == "yes":
        undercoat = True
else:
        undercoat = False

paintType = input("which type of paint will you use? wallpaper/luxury/standard/economy: ")

#calculate the area of the wall, using correct BIDMAS
area = ( (int(wallOne) * int(height) ) + ( int(wallTwo) * int(height) ) ) * 2

#calculate the cost of the paint based on its type, and the area of the walls.
if paintType == "wallpaper":
        if undercoat == True:
                paintCost = (area * 8) + (area * 0.5)
        else:
                paintCost = area * 8

elif paintType == "luxury":
        if undercoat == True:
                paintCost = (area * 1.75) + (area * 0.5)
        else:
                paintCost = area * 1.75

elif paintType == "standard":
        if undercoat == True:
                paintCost = area + (area * 0.5)
        else:
                paintCost = area

elif paintType == "economy":
        if undercoat == True:
                paintCost = (area * 0.45) + (area * 0.5)
        else:
                paintCost = area * 0.45

#calculate the time cost and the total
timeCost = (area / 4) * 12
totalCost = timeCost + paintCost

#display the results
print("Cost of Paint:   £", paintCost)
print("Cost of painter: £", timeCost)
print("Total Cost:      £", totalCost)

input("press any key to exit")
