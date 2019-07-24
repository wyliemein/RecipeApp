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
         "https://www.allrecipes.com/recipe/90209/italian-peas/",
        "https://www.allrecipes.com/recipe/100606/beef-bulgogi/",
         "https://www.allrecipes.com/recipe/25678/beef-stew-vi/",
         "https://www.allrecipes.com/recipe/30575/blue-cheese-beef-tenderloin/",
         "https://www.allrecipes.com/recipe/8270/sams-famous-carrot-cake/"

         
    ]

vegetarian=["steak","bacon", "beef", "lamb", "pork", "snail",
                "chicken", "turkey", "goose", "duck", "quail" ,"salmon", "tuna", "albacore", "anchovies",
                "shrimp", "squid", "scallops", "calamari", "mussels", "crab", "lobster", "fish"]
pescatarian=["steak","bacon", "beef", "lamb", "pork", "snail",
                "chicken", "turkey", "goose", "duck", "quail"]
vegan=["steak","bacon", "beef", "lamb", "pork", "snail",
                "chicken", "turkey", "goose", "duck", "quail" ,"salmon", "tuna", "albacore", "anchovies",
                "shrimp", "squid", "scallops", "calamari", "mussels", "crab", "lobster", "fish",
            "milk", "yogurt", "cheese", "butter", "ice cream","cream", "eggs", "honey", "bee pollen",
            "whey", "gelatin", "honeycomb", "lard", "fish sauce", "chicken broth","bone broth"]

glutenfree=["Pasta", "bread", "crackers", "semolina","rice"
                , "barley", "oats", "rye", "soy sauce", "chicken broth"]

name=[]
allrecipes=[]

for web in weblist:
    ingredient=[]
    categroy=[]
    recipes=[]
    driver.get(web)
    content = driver.page_source
    soup = BeautifulSoup(content)
    ingre=[]
    for i in soup.findAll('label', attrs={'ng-class':"{true: 'checkList__item'}[true]"}):
        ingredient.append(i.text)
    try:
        driver.get(web+"/fullrecipenutrition/")
    except:
        driver.get(web+"/fullrecipenutrition/")
    content = driver.page_source
    soup = BeautifulSoup(content)
    c=soup.find('h2')
    name.append(c.text)
    recipes.append(c.text)
    recipes.append(web)
    calplace=soup.find('div', attrs={'class':'nutrition-top light-underline'})
    queue = [int(s) for s in calplace.text.split() if s.isdigit()]
    recipes.append(queue[1])
    
    for a in soup.findAll('div', attrs={'class':'nutrition-row'}):
        weight=a.find('span', attrs={'class':'nutrient-value'})
        recipes.append(weight.text)
    recipes.append(ingredient)
    
    vege=True
    vega=True
    pesc=True
    glut=True
    for i in ingredient:
        
        if any(word in i for word in vegetarian):
            vege=False
        if any(word in i for word in pescatarian):
            pesc=False
        if any(word in i for word in vegan):
            vega=False
        if any(word in i for word in glutenfree):
            glut=False
    if vega==True:
        categroy.append('vegan')
    if vege==True:
        categroy.append('vegetarian')
    if glut==True:
        categroy.append('gluten free')
    if pesc==True:
        categroy.append('pescatarian')
    if vege=False and vega=False and pesc=False and glut=False:
        categroy.append('none')
    recipes.append(categroy)
    allrecipes.append(recipes)

df = pd.DataFrame(allrecipes,index=name, columns = [ 'Name','URL', 'Calories', 'TotalFat','SaturatedFat','Cholesterol','Sodium'
                   ,'Potassium','TotalCarbohydrates','DietaryFiber','Protein'
                   ,'Sugars','VitaminA','VitaminC','Calcium'
                   ,'Iron','Thiamin','Niacin','VitaminB6'
                   ,'Magnesium', 'Folate','Ingredient','Categroy'])
df.to_csv('result.csv')


