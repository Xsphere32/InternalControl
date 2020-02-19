import { BaseModel } from './baseModel';
import { GroupOfIndicators } from './groupOfIndicatorsModel';
import { Indicator } from './indicatorModel';
export class Question implements BaseModel{
    public Id: number;    
    public Name: string;
    public Answer: boolean;
    public GroupOfIndicators: GroupOfIndicators;
    public Indicator: Indicator;
}