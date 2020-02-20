import { BaseModel } from './baseModel';
import { GroupOfIndicators } from './groupOfIndicatorsModel';
import { Indicator } from './indicatorModel';
import { TypeOfForm } from './typeOfFormModel';
export class Question implements BaseModel{
    public Id: number;    
    public Name: string;
    public Answer: boolean;
    public GroupOfIndicators: GroupOfIndicators = new GroupOfIndicators();
    public Indicators: Indicator = new Indicator();
    public TypeOfForm: TypeOfForm = new TypeOfForm();
}