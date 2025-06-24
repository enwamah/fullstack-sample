import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Category } from '../../models/category';
import { CreateProductDto, Product } from '../../models/product';
import { CategoryService } from '../../services/category.service';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-form',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './product-form.html',
  styleUrl: './product-form.css'
})
export class ProductForm {
  categories: Category[] = [];
  productForm = new FormGroup({
    name: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    price: new FormControl(0.01, [Validators.required, Validators.min(0.01)]),
    categoryId: new FormControl('1', Validators.required)
  });

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe({
      next: (data: Category[]) => {
        this.categories = data;
      },
      error: (err: any) => {
        alert('Failed to load categories');
      }
    });
  }

  onSubmit() {
    if (this.productForm.valid) {
      const product: CreateProductDto = {
        name: this.productForm.value.name!,
        description: this.productForm.value.description!,
        price: this.productForm.value.price!,
        categoryId: +this.productForm.value.categoryId!
      };

      this.productService.createProduct(product).subscribe({
        next: (createdProduct: Product) => {
          this.router.navigate(['/products']);
        },
        error: (err: any) => {
          let alertmessage = 'Failed to create product.';

          if (err?.error?.errors) {
            alertmessage = Object.values(err.error.errors).flat().join('\n')
          }

          alert(alertmessage);
        }
      });
    }
  }
}
