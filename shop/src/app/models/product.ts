export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  categoryId: number;
}

export type CreateProductDto = Omit<Product, 'id'>;
