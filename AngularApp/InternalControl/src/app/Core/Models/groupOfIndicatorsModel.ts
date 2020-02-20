import { BaseModel } from './baseModel';
import { TypeOfForm } from './typeOfFormModel';
export class GroupOfIndicators implements BaseModel{
    public Id: number;    
    public Name: string;
    public TypeOfForm: TypeOfForm = new TypeOfForm();
}