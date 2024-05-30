export interface Product {
  barCode: string
  name: string
  description: string
  price: number
  stockQuantity: number
  id: string
  tmStmp: string
}


export interface AddProductPetition {
  barCode: string
  name: string
  description: string
  price: number
  stockQuantity: number
}
