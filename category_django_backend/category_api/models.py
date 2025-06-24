from django.db import models

class Category(models.Model):
    id = models.AutoField(db_column='Id', primary_key=True)  
    name = models.TextField(db_column='Name')  
    description = models.TextField(db_column='Description')  

    class Meta:
        managed = False
        db_table = 'Categories'