import { Activity } from "../../../app/models/activity";
import { Segment, Item, Button, Label } from "semantic-ui-react";

interface Props {
  activities: Activity[]; // Replace with your own Activity type definition.
  selectActivity: (id: string) => void;
  deleteActivity: (id: string) => void;
}

export default function ActivityList({
  activities,
  selectActivity,
  deleteActivity,
}: Props) {
  return (
    <Segment>
      <Item.Group divided>
        {activities.map((activity) => (
          <Item key={activity.id}>
            <Item.Content>
              <Item.Header as="a">{activity.title}</Item.Header>
              <Item.Meta>
                <span>{activity.date}</span>
              </Item.Meta>
              <Item.Description>
                <div>{activity.description}</div>
                <div>
                  {activity.city}, {activity.venue}
                </div>
              </Item.Description>
            </Item.Content>
            <Item.Extra>
              <Button
                floated="right"
                content="View"
                color="blue"
                onClick={() => selectActivity(activity.id)}
              ></Button>
              <Button
                onClick={() => deleteActivity(activity.id)}
                floated="right"
                content="Delete"
                color="red"
              />
              <Label basic content={activity.category} />
            </Item.Extra>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
