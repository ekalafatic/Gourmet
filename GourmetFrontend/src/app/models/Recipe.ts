import { Ingredient } from "./Ingredient";

export interface Recipe {
    recipeId:    number;
    recipeTitle: string;
    ingredients: Ingredient[];
}