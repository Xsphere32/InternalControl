import { BaseModel } from './baseModel';
import { GroupOfIndicators } from './groupOfIndicatorsModel';
export class Indicator implements BaseModel{
    public Id: number;    
    public Name: string;
    public GroupOfIndicators: GroupOfIndicators;
    
}