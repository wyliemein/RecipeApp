from selenium import webdriver
from bs4 import BeautifulSoup
import pandas as pd

driver = webdriver.Chrome("C:/Users/Zeyu Gao/Downloads/chromedriver_win32/chromedriver")

#add website here
weblist=["https://www.allrecipes.com/recipe/16259/ds-famous-salsa/",
         "https://www.allrecipes.com/recipe/255220/pineapple-sticky-ribs/",
         "https://www.allrecipes.com/recipe/25445/key-west-chicken/",
         "https://www.allrecipes.com/recipe/67952/roasted-brussels-sprouts/",
         "https://www.allrecipes.com/recipe/165190/spicy-vegan-potato-curry/",
         "https://www.allrecipes.com/recipe/217002/quinoa-and-black-bean-chili/",
         "https://www.allrecipes.com/recipe/229733/simple-roasted-butternut-squash/",
         "https://www.allrecipes.com/recipe/223042/chicken-parmesan/",
         "https://www.allrecipes.com/recipe/51283/maple-salmon/",
         "https://www.allrecipes.com/recipe/202467/grilled-bacon-wrapped-corn-on-the-cob/",
         "https://www.allrecipes.com/recipe/7565/too-much-chocolate-cake/",
         "https://www.allrecipes.com/recipe/199263/zippy-summer-shrimp/",
         "https://www.allrecipes.com/recipe/71698/sesame-seared-tuna/",
         "https://www.allrecipes.com/recipe/133128/peppered-shrimp-alfredo/",
         "https://www.allrecipes.com/recipe/257436/gluten-free-pizza-crust-or-flatbread/",
         "https://www.allrecipes.com/recipe/18288/garlic-green-beans/",
         "https://www.allrecipes.com/recipe/49552/quinoa-and-black-beans/",
         "https://www.allrecipes.com/recipe/83097/authentic-german-potato-salad/",
         "https://www.allrecipes.com/recipe/19125/chicken-and-red-wine-sauce/",
         "https://www.allrecipes.com/recipe/90209/italian-peas/"
         
    ]


name=[]
Calories=[]
TotalFat=[] 
SaturatedFat=[] 
Cholesterol=[]
Sodium=[]
Potassium=[]
TotalCarbohydrates=[]
DietaryFiber=[]
Protein=[]
Sugars=[]
VitaminA=[]
VitaminC=[]
Calcium=[]
Iron=[]
Thiamin=[]
Niacin=[]
VitaminB6=[]
Magnesium=[]
Folate=[]


alldata=[name, TotalFat, SaturatedFat,Cholesterol,Sodium,Potassium, TotalCarbohydrates,DietaryFiber,Protein,Sugars
,VitaminA,VitaminC,Calcium,Iron,Thiamin,Niacin,VitaminB6,Magnesium ,Folate]

for web in weblist:
    driver.get(web+"/fullrecipenutrition/")
    
    content = driver.page_source
    soup = BeautifulSoup(content)
    b=1
    c=soup.find('h2')
    alldata[0].append(c.text)
    calplace=soup.find('div', attrs={'class':'nutrition-top light-underline'})
    queue = [int(s) for s in calplace.text.split() if s.isdigit()]
    Calories.append(queue[1])
    
    for a in soup.findAll('div', attrs={'class':'nutrition-row'}):
        weight=a.find('span', attrs={'class':'nutrient-value'})
        alldata[b].append(weight.text)
        b+=1
df = pd.DataFrame({'Name':name,'Calories': Calories, 'Total Fat':TotalFat,'Saturated Fat':SaturatedFat,'Cholesterol':Cholesterol,'Sodium':Sodium
                   ,'Potassium':Potassium,'Total Carbohydrates':TotalCarbohydrates,'Dietary Fiber':DietaryFiber,'Protein':Protein
                   ,'Sugars':Sugars,'Vitamin A':VitaminA,'Vitamin C':VitaminC,'Calcium':Calcium
                   ,'Iron':Iron,'Thiamin':Thiamin,'Niacin':Niacin,'Vitamin B6':VitaminB6
                   ,'Magnesium':Magnesium, 'Folate':Folate}) 
df.to_csv('result.csv', index=False, encoding='utf-8')
