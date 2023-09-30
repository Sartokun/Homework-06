/*----------------------------------------------------------------
****โปรดอ่าน****
โค้ดนี้จัดทำเพื่อการอธิบายการทำงานของ method Find (Homework 6: ทดลองสร้าง Method Find)

- แก้ไข method SearchRecipeWithIngredient ให้สามารถค้นหาวัตถุดิบในรายการของ Recipe ว่ามีวัตถุดิบตามข้อมูล input หรือไม่ (สามารถใช้ C# String Contains() ช่วยได้)
- https://www.geeksforgeeks.org/c-sharp-string-contains-method/

*โปรดอ่านคำอธิบายและทดลองเขียนและทำความเข้าใจด้วยตัวเองก่อน หากไม่เข้าใจสามารถถามมาได้ผมจะตอบในช่วงที่สามารถตอบได้
**โดยผมได้สร้างสไลด์เขียนอธิบายเอาไว้แล้วบางส่วนสามารถเข้าไปอ่านได้**
- สไลด์ อธิบายเนื้อหา
https://docs.google.com/presentation/d/1tzSsUs34IagXxdNUK9PWypZfq-i9yN_SQDMVnQt9MOc/edit?usp=sharing

*โดยมีโค้ดที่อาจารเขียนมาให้แล้วบางส่วน เราก็แค่แก้ไข method SearchRecipeWithIngredient จากโค้ดที่อาจารส่งมา
- Download Code สำหรับการบ้านได้ที่นี่
https://drive.google.com/file/d/1HAzKVwGTqg6IA9ua4wk8wgm3vfHNwuXU/view?usp=sharing

**Trick(เล็กๆน้อยๆ)**
- หากต้องการจัดหน้าโค้ดให้เป็นระเบียบ โดยไม่ต้องมานั้งจัดเอง สามารถกด Alt + Shift + F (บน Windows) หรือ Option + Shift + F (บน macOS)
- หากต้องการเคลียร์หน้าจอ (Terminal) หรือ Command Prompt (หรือ Terminal อื่นๆ) 
  สามารถใช้คำสั่งเฉพาะของแต่ละระบบปฏิบัติการได้(พิมใน Terminal ได้เลย) cls (บน Windows) หรือ clear (บน macOS และ Linux) จากนั้นกด Enter

ด้วยความปรารถนาดีจาก ผู้สาวซาโต้จัง🌸🌈 (sarto_)
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

public class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }

    public Recipe(string name, List<string> ingredients)
    {
        this.Name = name;
        this.Ingredients = ingredients;
    }
}

public class RecipeManagementSystem
{
    public static Recipe SearchRecipeWithIngredient(List<Recipe> recipeList, string ingredient) //สร้าง method โดยส่งค่าเป็น Recipe และตั้งชื่อว่า SearchRecipeWithIngredient โดยรับค่ามาเป็น List<Recipe> ตั้งชื่อว่า recipeList และค่า string ชื่อ ingredient
    {
        foreach (Recipe recipe in recipeList) //เริ่มต้นด้วยการวนลูปผ่านรายการสูตรอาหารที่มีอยู่ใน recipeList โดยใช้ลูป foreach เพื่อเข้าถึงแต่ละสูตรอาหารที่อยู่ใน recipeList
        {
            if (recipe.Ingredients.Any(ingredientInRecipe => ingredientInRecipe.Contains(ingredient, StringComparison.OrdinalIgnoreCase))) //สำหรับแต่ละสูตรอาหาร (recipe) จะมีการตรวจสอบว่ามีวัตถุดิบในรายการส่วนผสม (Ingredients) ที่ตรงกับ ingredient ที่ถูกส่งเข้ามาหรือไม่ โดยใช้ recipe.Ingredients.Any(...) เพื่อตรวจสอบในแต่ละสูตร
            {
                return recipe; //หากพบว่ามีสูตรอาหารที่มีวัตถุดิบที่ตรงกับ ingredient จะคืนสูตรอาหารนั้นและจบการทำงานของเมธอดทันที ซึ่งหมายความว่าจะไม่ค้นหาสูตรอาหารอื่น ๆ ต่อ
            }
        }
        return null; //หากไม่พบสูตรอาหารที่มีวัตถุดิบที่ตรงกับ ingredient ในรายการส่วนผสมของทุกสูตร จะคืนค่า null เพื่อแสดงว่าไม่พบสูตรอาหารที่ตรงตามเงื่อนไข
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Recipe> recipeList = new List<Recipe>();

        Recipe padThaiRecipe = new Recipe(
            "Pad Thai Noodles",
            new List<string>
            {
                "200g flat rice noodles",
                "150g firm tofu, cubed",
                "2 eggs, beaten",
                "3 tablespoons Pad Thai sauce"
            }
        );

        Recipe tomYumRecipe = new Recipe(
            "Tom Yum Soup",
            new List<string>
            {
                "500ml chicken or vegetable broth",
                "200g shrimp, peeled and deveined",
                "200g mushrooms, sliced",
                "2-3 tablespoons Tom Yum paste"
            }
        );

        recipeList.Add(padThaiRecipe);
        recipeList.Add(tomYumRecipe);

        Recipe recipeWithTofu = RecipeManagementSystem.SearchRecipeWithIngredient(recipeList, "tofu");
        if (recipeWithTofu == null)
        {
            Console.WriteLine("Recipe with tofu not found");
        }
        else
        {
            Console.WriteLine(recipeWithTofu.Name);
        }

        Recipe recipeWithTruffle = RecipeManagementSystem.SearchRecipeWithIngredient(recipeList, "truffle");
        if (recipeWithTruffle == null)
        {
            Console.WriteLine("Recipe with truffle not found");
        }
        else
        {
            Console.WriteLine(recipeWithTruffle.Name);
        }
    }
}

