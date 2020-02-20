import { BaseModel } from './baseModel';
import { GroupOfIndicators } from './groupOfIndicatorsModel';
import { TypeOfForm } from './typeOfFormModel';
export class Indicator implements BaseModel{
    public Id: number;    
    public Name: string;
    public GroupOfIndicators: GroupOfIndicators = new GroupOfIndicators();
    public TypeOfForm: TypeOfForm = new TypeOfForm();
}