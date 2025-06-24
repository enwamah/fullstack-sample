import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { CategoryService } from '../../services/category.service';
import { Product } from '../../models/product';
import { Category } from '../../models/category';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products-list',
  imports: [CommonModule],
  templateUrl: './products-list.html',
  styleUrl: './products-list.css'
})

export class ProductsList {
  products: Product[] = [];
  categories: Category[] = [];
  categoryMap = new Map<number, string>();

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe({
      next: (data: Product[]) => {
        this.products = data;
      },
      error: (err: any) => {
        console.error('Failed to load products', err);
        alert('Failed to load products');
      }
    });


    this.categoryService.getCategories().subscribe({
      next: (data: Category[]) => {
        this.categories = data;
        this.categoryMap = new Map(this.categories.map(c => [c.id, c.name]));
      },
      error: (err: any) => {
        console.error('Failed to load categories', err);
        alert('Failed to load categories');
      }
    });
  }

  getCategoryNameById(id: number): string {
    return this.categoryMap.get(id) ?? 'Unknown';
  }
}
