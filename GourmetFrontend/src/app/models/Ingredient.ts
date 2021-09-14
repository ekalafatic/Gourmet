import { Food } from "./Food";

export interface Ingredient{
    ingredientId: number,
    food:         Food;
    amount:       number;
}