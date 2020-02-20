import { TypeOfForm } from './typeOfFormModel';
import { GroupOfIndicators } from './groupOfIndicatorsModel';
import { Indicator } from './indicatorModel';
export class PostFilter {
    public TypeOfForm: TypeOfForm = new TypeOfForm();
    public GroupOfIndicators: GroupOfIndicators = new GroupOfIndicators();
    public Indicators: Indicator = new Indicator();
}